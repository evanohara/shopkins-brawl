using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkinBaseCharacter : MonoBehaviour
{
    protected float baseSpeed = 2.0f;
    public Player player;
    protected Rigidbody2D rb;
    internal SpriteRenderer sr;
    internal Animator animator;

    void Awake()
    {
        if (player == null)
            player = GetComponentInParent<Player>();
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    internal void Update()
    {
        float lh = player.GetHorizontal();
        animator.SetFloat("Horizontal", lh);

        if (lh > 0.1f || lh < -0.1f)
        {
            rb.velocity = new Vector2(lh * baseSpeed, rb.velocity.y);
        }
        else
            rb.velocity = new Vector2(0, rb.velocity.y);
    }
}
