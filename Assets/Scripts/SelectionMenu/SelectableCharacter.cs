using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableCharacter : MonoBehaviour
{
    public ShopkinBaseCharacter character;
    public SelectableCharacter leftChar;
    public SelectableCharacter rightChar;

    private List<PlayerCharacterSelector> occupyingPlayers = new List<PlayerCharacterSelector>();
    public bool HasBeenSelected { get; set; }


    internal void AddOccupyingPlayer(PlayerCharacterSelector p)
    {
        occupyingPlayers.Add(p);
    }
    internal void RemoveOccupyingPlayer(PlayerCharacterSelector p)
    {
        occupyingPlayers.Remove(p);
    }

    internal bool HasOccupyingPlayers()
    {
        return (occupyingPlayers.Count > 0);
    }
}
