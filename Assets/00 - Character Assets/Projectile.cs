using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ShopkinBaseCharacter;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float speed = 10f;
    internal ShopkinBaseCharacter _shooter;
    public float impactWeight = 2f;
    public float maxLifeSpan = 1f;
    public Timer despawnTimer;

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        if (despawnTimer == null)
        {
            despawnTimer = gameObject.AddComponent<Timer>();
            despawnTimer.SetAndStart(maxLifeSpan);
        }
        if (animator == null)
            animator = GetComponent<Animator>();

    }

    private void Update()
    {
        if (despawnTimer.Triggered())
            StartCoroutine("StartDestructionSequence");

    }

    public void Project(Facing direction, ShopkinBaseCharacter shooter)
    {
        _shooter = shooter;
        switch (direction)
        {
            case Facing.Left:
                SetMotion(new Vector2(-speed, 0));
                break;
            case Facing.Right:
                SetMotion(new Vector2(speed, 0));
                break;
        }
    }

    private void SetMotion(Vector2 direction)
    {
        rb.velocity = direction;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Character")
        {
            ShopkinBaseCharacter character = collider.GetComponent<ShopkinBaseCharacter>();
            if (character != _shooter)
            {
                //Debug.Log(name + ": Chip hit a target.");
                animator = GetComponent<Animator>();
                StartCoroutine("StartDestructionSequence");
            }
        }
    }

    public Vector2 GetVelocityUnitVector()
    {
        return rb.velocity.normalized;
    }
    public float GetImpactWeight()
    {
        return impactWeight;
    }

    private IEnumerator StartDestructionSequence()
    {
        float randomStopTime = Random.Range(0.02f, 0.06f);
        yield return new WaitForSeconds(randomStopTime);
        rb.velocity = Vector2.zero;
        animator.SetTrigger("HitTarget");
        yield return new WaitForSeconds(0.33f);
        Destroy(gameObject);
    }
}
