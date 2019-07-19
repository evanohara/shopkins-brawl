using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MatchCharacterAssigner;

public class SelectableCharacter : MonoBehaviour
{
    public ShopkinCharacters character;
    public SelectableCharacter leftChar;
    public SelectableCharacter rightChar;
#pragma warning disable 0649
    [SerializeField]
    private AudioClip _confirmationClip;
#pragma warning restore 0649

    private List<PlayerCharacterSelectionController> occupyingPlayers = new List<PlayerCharacterSelectionController>();
    public bool HasBeenSelected { get; set; }


    internal void AddOccupyingPlayer(PlayerCharacterSelectionController p)
    {
        occupyingPlayers.Add(p);
    }
    internal void RemoveOccupyingPlayer(PlayerCharacterSelectionController p)
    {
        occupyingPlayers.Remove(p);
    }

    internal bool HasOccupyingPlayers()
    {
        return (occupyingPlayers.Count > 0);
    }

    public AudioClip GetConfirmationClip()
    {
        return _confirmationClip;
    }
}
