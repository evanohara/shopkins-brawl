using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionMenu : MonoBehaviour
{
    public List<SelectableCharacter> selectableCharacters = new List<SelectableCharacter>();
    public int numRows = 1;

    public List<PlayerCharacterSelector> playerSelectors = new List<PlayerCharacterSelector>();

    private List<int> activePlayers = new List<int>();

    public AudioClip selectionSound;

    // Update is called once per frame
    void Update()
    {
        // Determine if the game should start.
        if (Input.GetButtonDown("AnyStart"))
        {
            Debug.Log(this.name + ": Loading Scene");
            if (AllAreReady() && AtLeastTwoPlayers())
            {
                StartCoroutine(LoadAsyncScene());
            }
        }

        // Determine character selection
        foreach (PlayerCharacterSelector p in playerSelectors)
        {
            // Player Activation and Final Selection
            if (p.player.ButtonIsDown(PlayerInput.Button.B))
            {
                Debug.Log(this.name + ": Player " + p.player.playerNumber + " has pressed B.");
                if (!activePlayers.Contains(p.player.playerNumber))
                {
                    ActivatePlayer(p);
                }
                else
                {
                    if (!p.SelectionFinalized)
                    {
                        Debug.Log(this.name + ": Finishing character selection.");
                        p.FinalizeSelection();
                    }
                }
            }

            // Player Moving Selection
            if (p.canSelect)
            {
                PlayerInput.Direction direction = p.player.GetMajorDirection();
                switch (direction)
                {
                    case PlayerInput.Direction.None:
                        break;
                    case PlayerInput.Direction.Left:
                        p.SetTargetCharacter(p.targetCharacter.leftChar);
                        break;
                    case PlayerInput.Direction.Right:
                        p.SetTargetCharacter(p.targetCharacter.rightChar);
                        break;
                    case PlayerInput.Direction.Up:
                        break;
                    case PlayerInput.Direction.Down:
                        break;
                }
            }
        }
    }

    private bool AtLeastTwoPlayers()
    {
        int numReady = 0;

        foreach (PlayerCharacterSelector s in playerSelectors)
        {
            if (s.SelectionFinalized)
                numReady++;
        }
        return (numReady > 1);
    }

    private bool AllAreReady()
    {
        foreach (PlayerCharacterSelector s in playerSelectors)
        {
            if (s.active && !s.SelectionFinalized)
            {
                Debug.Log(this.name + ": Player Not Ready.");
                return false;
            }
        }

        Debug.Log(this.name + ": All Players Ready.");
        return true;
    }

    private void ActivatePlayer(PlayerCharacterSelector p)
    {
        Debug.Log(this.name + ": Player was not active and is now being activated.");
        activePlayers.Add(p.player.playerNumber);
        p.Activate();
        SetPlayerSelectionToFirstUntargeted(p);
    }

    private void SetPlayerSelectionToFirstUntargeted(PlayerCharacterSelector p)
    {
        foreach (SelectableCharacter selectableCharacter in selectableCharacters)
        {
            if (!selectableCharacter.HasOccupyingPlayers())
            {
                selectableCharacter.AddOccupyingPlayer(p);
                Debug.Log(this.name + ": Setting to untargeted char BITCH.");
                p.SetTargetCharacter(selectableCharacter);
                return;
            }
        }
        Debug.LogError(this.name + ": Target never set");
    }

    IEnumerator LoadAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LevelOne");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
