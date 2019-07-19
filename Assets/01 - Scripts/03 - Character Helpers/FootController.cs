using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootController : MonoBehaviour
{
    public ShopkinBaseCharacter character;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Foot Has Entered A Collision.");
        if (collision.collider.tag == "Ground")
        {
            character.CanJump = true;
            Debug.Log("Character can jump.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Foot Has Entered A Trigger.");
        if (collider.tag == "Ground")
        {
            character.CanJump = true;
            //Debug.Log("Character can jump.");
        }
    }
}
