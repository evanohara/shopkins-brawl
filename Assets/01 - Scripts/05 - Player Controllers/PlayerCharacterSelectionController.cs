using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSelectionController : PlayerController
{
    private readonly static float SELECTIONTIMER = 0.3f;
    public PlayerSelectionTargetUI playerSelectionTargetUI;
    public PlayerSelectionUI playerSelectionUI;
    private float remainingTimeBeforeNextSelectionMoveIsAllowed;

    internal bool SelectionFinalized { get; set; }
    internal bool active = false;
    internal bool canSelect = false;

    internal SelectableCharacter targetCharacter;

    private void Update()
    {
        if (active)
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
    }

    internal void Activate()
    {
        playerSelectionTargetUI.EnableSelection();
        active = true;
        canSelect = true;
    }

    internal void SetTargetCharacter(SelectableCharacter character)
    {
        playerSelectionTargetUI.transform.position = character.transform.position;
        playerSelectionUI.ChangeToSelectedCharacter(character);
        targetCharacter = character;
        canSelect = false;
        remainingTimeBeforeNextSelectionMoveIsAllowed = SELECTIONTIMER;
    }

    internal void FinalizeSelection()
    {
        if (targetCharacter == null)
        {
            Debug.LogError(name + ": Target is null.");
            return;
        }
        playerSelectionTargetUI.FinalizeAnimation();
        SelectionFinalized = true;
        canSelect = false;
        AudioManager.instance.Play(targetCharacter.GetConfirmationClip());
        Game.instance.GetComponent<MatchCharacterAssigner>().GiveAssignment(playerNumber, targetCharacter.character);
    }


}
