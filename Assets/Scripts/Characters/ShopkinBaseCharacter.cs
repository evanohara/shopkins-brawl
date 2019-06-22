using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkinBaseCharacter : MonoBehaviour
{
    protected float baseSpeed = 1.0f;
    public Player player;
    protected Rigidbody2D rb;
    internal SpriteRenderer sr;

    void Awake()
    {
        if (player == null)
            player = GetComponentInParent<Player>();
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float lh = player.GetHorizontal();
        Debug.Log(lh);

        if (lh > 0.1f || lh < -0.1f)
        {
            Debug.Log(this.name + ": moving.");
            rb.velocity = new Vector2(lh * baseSpeed, rb.velocity.y);
        }
        else
            rb.velocity = new Vector2(0, rb.velocity.y);
    }
}
