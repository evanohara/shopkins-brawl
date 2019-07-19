using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchCharacterAssigner : MonoBehaviour
{
    public List<GameObject> characterPrefabs;

    ShopkinCharacters[] playerSelections = new ShopkinCharacters[4] { ShopkinCharacters.None, ShopkinCharacters.None, ShopkinCharacters.None, ShopkinCharacters.None };

    public void GiveAssignment(int playerId, ShopkinCharacters selection)
    {
        playerSelections[playerId - 1] = selection;
    }

    public GameObject TakeAssignment(int playerId)
    {
        ShopkinCharacters character = playerSelections[playerId - 1];
        if (character == ShopkinCharacters.None)
            return null;
        return characterPrefabs[(int)character];
    }

    public enum ShopkinCharacters { KookyCookie, AppleBlossom, CheekyChocolate, CupcakeChic, None }
}
