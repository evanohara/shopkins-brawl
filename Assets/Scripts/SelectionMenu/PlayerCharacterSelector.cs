using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSelector : MonoBehaviour
{
    private readonly static float SELECTIONTIMER = 0.3f;

    public Player player;
    public PlayerSelectionTargetUI playerSelectionTargetUI;
    public PlayerSelectionUI playerSelectionUI;
    private float remainingTimeBeforeNextSelectionMoveIsAllowed;

    internal bool SelectionFinalized { get; set; }
    internal bool active = false;
    internal bool canSelect = true;

    internal SelectableCharacter targetCharacter;

    private void Update()
    {
        if (!canSelect && !SelectionFinalized)
        {
            remainingTimeBeforeNextSelectionMoveIsAllowed -= Time.deltaTime;
            if (remainingTimeBeforeNextSelectionMoveIsAllowed < 0)
            {
                canSelect = true;
            }
        }
    }

    internal void Activate()
    {
        Debug.Log(this.name + ": Activating Selector.");
        playerSelectionTargetUI.EnableSelection();
        //Debug.Log(this.name + ": Player can select.");
        active = true;
    }

    internal void SetTargetCharacter(SelectableCharacter character)
    {
        Debug.Log(this.name + ": Setting target character.");
        playerSelectionTargetUI.transform.position = character.transform.position;
        playerSelectionUI.ChangeToSelectedCharacter(character);
        targetCharacter = character;
        //Debug.Log(this.name + ": Player cannot select.");
        canSelect = false;
        remainingTimeBeforeNextSelectionMoveIsAllowed = SELECTIONTIMER;
    }

    internal void FinalizeSelection()
    {
        Debug.Log(this.name + ": Finalizing Selection.");
        playerSelectionTargetUI.FinalizeAnimation();

        if (targetCharacter == null)
        {
            Debug.LogError(this.name + ": Target is null.");
        }
        player.AssignCharacter(targetCharacter.character);
        SelectionFinalized = true;
        canSelect = false;

        player.tag = "ActivePlayer";
    }


}
