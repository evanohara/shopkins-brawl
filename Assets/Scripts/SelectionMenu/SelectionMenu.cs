using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static PlayerInput;

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
        HandlePlayersInput();
    }

    private void HandlePlayersInput()
    {
        // Determine if the game should start.
        if (Input.GetButtonDown("AnyStart"))
        {
            if (GameShouldStart())
            {
                Debug.Log(this.name + ": Loading Scene");
                StartCoroutine(LoadAsyncScene());
            }
        }

        // Determine character selection
        foreach (PlayerCharacterSelector p in playerSelectors)
        {
            // Player Activation and Final Selection
            if (p.player.ButtonIsDown(Button.B))
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
                Direction direction = p.player.GetMajorDirection();
                switch (direction)
                {
                    case Direction.None:
                        break;
                    case Direction.Left:
                        p.SetTargetCharacter(p.targetCharacter.leftChar);
                        break;
                    case Direction.Right:
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

    private bool GameShouldStart()
    {
        return AtLeastTwoPlayers() && AllAreReady();
    }

    private bool AtLeastTwoPlayers()
    {
        int numReady = 0;

        foreach (PlayerCharacterSelector s in playerSelectors)
        {
            if (s.SelectionFinalized)
                numReady++;
        }
        if (TESTING.Testing())
            return (numReady > 0);
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
        SetPlayerSelectionToUntargeted(p);
    }

    private void SetPlayerSelectionToUntargeted(PlayerCharacterSelector p)
    {
        foreach (SelectableCharacter selectableCharacter in selectableCharacters)
        {
            if (!selectableCharacter.HasOccupyingPlayers())
            {
                selectableCharacter.AddOccupyingPlayer(p);
                Debug.Log(name + ": Setting to untargeted char.");
                p.SetTargetCharacter(selectableCharacter);
                return;
            }
        }
        Debug.LogError(name + ": Target never set");
    }

    IEnumerator LoadAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("StreetsOfShopville");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
