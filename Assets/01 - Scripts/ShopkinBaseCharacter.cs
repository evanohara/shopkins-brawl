using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ShopkinBaseCharacter : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
    protected Animator animator;



    public PlayerCharacterController player;

    [SerializeField]
    private int maxHealth = 100;
    private int currentHealth;

    [SerializeField]
    private float maxVelocity = 25f;
    [SerializeField]
    private float force = 1f;
    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private float _attackBWait = 0.5f;
    private Timer _attackBTimer;

    protected Facing facingDirection = Facing.Right;

    public bool CanJump { get; set; } = true;
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

    public int MaxHealth => maxHealth;

    protected virtual void Update()
    {
        CheckAttackB();
        CheckDead();
        CheckWalk();
        CheckJump();
    }

    private void CheckWalk()
    {
        float lh = player.GetHorizontal();
        animator.SetFloat("Horizontal", lh);

        if (player.IsTryingToMove())
        {

            //rb.velocity = new Vector2(lh * BASESPEED * _characterSpeedMultiplier, rb.velocity.y);
            if (lh < -0.12f)
            {
                PhysicsHelper.ApplyForceToReachVelocity(rb, new Vector2(-maxVelocity, 0), force);
                //rb.AddForce(new Vector2(-force, 0f));
                TurnLeft();
            }
            else
            {
                PhysicsHelper.ApplyForceToReachVelocity(rb, new Vector2(maxVelocity, 0), force);
                //rb.AddForce(new Vector2(force, 0f));
                TurnRight();
            }
        }
    }
    private void CheckJump()
    {
        if (player.ButtonJustPressed(PlayerInput.Button.A))
        {
            Debug.Log("A pressed!");
            if (CanJump)
            {
                Debug.Log("Jumping!");
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                CanJump = false;
            }
        }
    }
    private void CheckAttackB()
    {
        if (player.ButtonJustPressed(PlayerInput.Button.B))
        {
            if (_attackBTimer.Triggered())
            {
                animator.SetTrigger("ThrowChip");
                AttackB();
                _attackBTimer.ResetAndStart();
            }
        }
    }
    protected void CheckDead()
    {
        if (CurrentHealth <= 0)
        {
            Match.instance.activePlayers.Remove(player);
            Destroy(gameObject);
        }
    }
    private void TurnLeft()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        facingDirection = Facing.Left;
    }
    private void TurnRight()
    {
        transform.localScale = new Vector3(1, 1, 1);
        facingDirection = Facing.Right;
    }

    internal abstract void AttackB();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        CharacterCollisionHelper.HandleCollision(this, collider);
    }

    public void GotHit(int hpLoss, Vector2 direction, float weight)
    {
        animator.SetTrigger("GotHit");
        animator.SetBool("Blinking", true);
        CurrentHealth -= hpLoss;
        gameObject.AddComponent<BlinkingEffect>().StartEffect(sr, 1f);
        AudioManager.instance.PlayFromLibrary(AudioLibrary.SoundTag.Hit);
        Match.instance.ui.UpdateHealthIndicator(player.playerNumber, CurrentHealth);

        Vector2 force = new Vector2(direction.x * weight, 2.5f);
        StartCoroutine(ApplyForceNextFixedUpdate(force, ForceMode2D.Impulse));
    }


    protected IEnumerator ApplyForceNextFixedUpdate(Vector2 force, ForceMode2D forceMode)
    {
        yield return new WaitForFixedUpdate();
        rb.AddForce(force, forceMode);
        yield break;
    }

    public enum Facing { Left, Right }

    void Awake()
    {
        if (player == null)
            player = GetComponentInParent<PlayerCharacterController>();
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();
        if (animator == null)
            animator = GetComponent<Animator>();
        if (_attackBTimer == null)
        {
            _attackBTimer = gameObject.AddComponent(typeof(Timer)) as Timer;
            _attackBTimer.SetAndStart(_attackBWait);
        }
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
        Match.instance.ui.UpdateHealthIndicator(player.playerNumber, CurrentHealth);
    }
}
