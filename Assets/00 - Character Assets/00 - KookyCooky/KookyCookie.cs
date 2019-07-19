using UnityEngine;

public class KookyCookie : ShopkinBaseCharacter
{
    public GameObject chipPrefab;
    public Transform chipSpawnLocation;

    internal override void AttackB() // Throw Chocolate Chip!
    {
        Projectile newChipProj = Instantiate(chipPrefab, chipSpawnLocation.position, Quaternion.identity).GetComponent<Projectile>();
        animator.SetTrigger("ThrowChip");
        newChipProj.Project(facingDirection, this);
    }


}
