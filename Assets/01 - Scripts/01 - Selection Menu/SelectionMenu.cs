using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static PlayerInput;

public class SelectionMenu : MonoBehaviour
{
    public List<SelectableCharacter> selectableCharacters = new List<SelectableCharacter>();
    public int numRows = 1;

    public List<PlayerCharacterSelectionController> playerSelectors = new List<PlayerCharacterSelectionController>();

    private List<int> activePlayers = new List<int>();

    public AudioClip selectionSound;

    private void Update()
    {
        CheckStartGame();
        CheckSelectionMovement();
        CheckSelectionsMade();
        CheckGoBackMainMenu();
    }

    private void CheckSelectionsMade()
    {
        foreach (PlayerCharacterSelectionController p in playerSelectors)
        {
            if (p.ButtonJustPressed(Button.B))
            {
                if (!activePlayers.Contains(p.playerNumber))
                {
                    AudioManager.instance.PlayFromLibrary(AudioLibrary.SoundTag.Select);
                    ActivatePlayer(p);
                }
                else
                {
                    if (!p.SelectionFinalized)
                    {
                        p.FinalizeSelection();
                    }
                }
            }
        }
    }
    private void CheckSelectionMovement()
    {
        foreach (PlayerCharacterSelectionController p in playerSelectors)
        {
            if (p.canSelect)
            {
                Direction direction = p.GetMajorDirection();

                switch (direction)
                {

                    case Direction.None:
                        break;
                    case Direction.Left:
                        AudioManager.instance.PlayFromLibrary(AudioLibrary.SoundTag.MenuMove);
                        p.SetTargetCharacter(p.targetCharacter.leftChar);
                        break;
                    case Direction.Right:
                        AudioManager.instance.PlayFromLibrary(AudioLibrary.SoundTag.MenuMove);
                        p.SetTargetCharacter(p.targetCharacter.rightChar);
                        break;
                    case Direction.Up:
                        break;
                    case Direction.Down:
                        break;
                }
            }
        }
    }

    private void CheckStartGame()
    {
        if (Input.GetButtonDown("AnyStart"))
        {
            if (GameShouldStart())
                Game.instance.LoadScene("03 - StageSelectionMenu");

        }
    }

    private void CheckGoBackMainMenu()
    {
        if (Input.GetButtonDown("AnySelect"))
            Game.instance.LoadScene("01 - MainMenu");
    }

    private bool GameShouldStart()
    {
        return AtLeastTwoPlayers() && AllAreReady();
    }

    private bool AtLeastTwoPlayers()
    {
        int numReady = 0;

        foreach (PlayerCharacterSelectionController s in playerSelectors)
        {
            if (s.SelectionFinalized)
                numReady++;
        }
        if (Game.instance.TestModeOn)
            return (numReady > 0);
        return (numReady > 1);
    }

    private bool AllAreReady()
    {
        foreach (PlayerCharacterSelectionController s in playerSelectors)
        {
            if (s.active && !s.SelectionFinalized)
            {
                Debug.Log(name + ": Player Not Ready.", DLogType.Log);
                return false;
            }
        }

        return true;
    }

    private void ActivatePlayer(PlayerCharacterSelectionController p)
    {
        activePlayers.Add(p.playerNumber);
        p.Activate();
        SetPlayerSelectionToUntargeted(p);
    }

    private void SetPlayerSelectionToUntargeted(PlayerCharacterSelectionController p)
    {
        foreach (SelectableCharacter selectableCharacter in selectableCharacters)
        {
            if (!selectableCharacter.HasOccupyingPlayers())
            {
                selectableCharacter.AddOccupyingPlayer(p);
                p.SetTargetCharacter(selectableCharacter);
                return;
            }
        }
        Debug.Log(name + ": Target never set", DLogType.Exception);
    }


}
