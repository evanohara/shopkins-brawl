using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterCollisionHelper
{
    internal static void HandleCollision(ShopkinBaseCharacter character, Collider2D collider)
    {
        switch (collider.tag)
        {
            case "EnemyProjectile":
                Projectile proj = collider.GetComponent<Projectile>();
                if (proj._shooter != character)
                {
                    character.GotHit(10, proj.GetVelocityUnitVector(), proj.GetImpactWeight());
                }
                break;
            case "Ground":
                break;
            case "Item":
                Debug.Log("Pickupp");
                collider.GetComponent<Item>().OnPickUP(character);
                break;
            default:
                Debug.Log("Unhandled Collision with " + collider + ". Tag: " + collider.tag, DLogType.Exception);
                break;
        }
    }
}
