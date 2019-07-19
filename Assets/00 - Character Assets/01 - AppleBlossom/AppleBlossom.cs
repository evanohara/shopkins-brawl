using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBlossom : ShopkinBaseCharacter
{
    public GameObject flowerPrefab;
    public Transform flowerSpawnLocation;
    internal override void AttackB()
    {
        Projectile newChipProj = Instantiate(flowerPrefab, flowerSpawnLocation.position, Quaternion.identity).GetComponent<Projectile>();
        animator.SetTrigger("ThrowChip");
        newChipProj.Project(facingDirection, this);
    }
}
