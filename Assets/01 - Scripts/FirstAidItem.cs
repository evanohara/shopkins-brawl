using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidItem : Item
{
    public int healAmount = 30;
    public override void OnPickUP(ShopkinBaseCharacter character)
    {
        int health = character.CurrentHealth += 30;

        if (health > character.MaxHealth)
            character.CurrentHealth = character.MaxHealth;
        else
            character.CurrentHealth = health;

        Match.instance.ui.UpdateHealthIndicator(character.player.playerNumber, character.CurrentHealth);
        Destroy(gameObject);
    }
}
