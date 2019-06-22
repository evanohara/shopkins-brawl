using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakeChic : ShopkinBaseCharacter
{
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
