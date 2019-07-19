using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private List<PlayerSpawner> playerSpawners;

    List<PlayerSpawner> unallocatedSpawners;
#pragma warning restore 0649

    public List<PlayerCharacterController> players;
    public List<PlayerCharacterController> activePlayers;
    public static Match instance;
    public MatchUI ui;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);



        unallocatedSpawners = new List<PlayerSpawner>();

        foreach (PlayerSpawner spawner in playerSpawners)
        {
            unallocatedSpawners.Add(spawner);
        }
        foreach (PlayerCharacterController player in players)
        {
            GameObject charPrefab = Game.instance.GetComponent<MatchCharacterAssigner>().TakeAssignment(player.playerNumber);
            if (charPrefab != null)
            {
                ShopkinBaseCharacter character = Instantiate(charPrefab).GetComponent<ShopkinBaseCharacter>();
                character.transform.parent = player.transform;
                player.SetShopkin(character);
                SpawnPlayer(player);
                player.GetShopkin().GetComponentInChildren<PlayerIndicator>().SetIndicator(player.playerNumber);
                activePlayers.Add(player);
            }
        }

        if (Game.instance.TestModeOn)
        {
            Game.instance.testHelper.UpdateTestCanvasCamTarget(FindObjectOfType<Camera>());
            Game.instance.testHelper.testVariableExposer.SetTarget(players[0].GetShopkin());
        }

    }

    private void Update()
    {

        if (activePlayers.Count <= 1 && !Game.instance.TestModeOn)
            StartCoroutine(RunEndOfMatchSequence());

    }

    private void SpawnPlayer(PlayerCharacterController p)
    {
        int remainingUnusedSpawners = unallocatedSpawners.Count;
        int randomSpawnIndex = Random.Range(0, remainingUnusedSpawners);
        PlayerSpawner spawner = unallocatedSpawners[randomSpawnIndex];
        unallocatedSpawners.Remove(spawner);
        spawner.SetSpawnObject(p.GetShopkin().gameObject);
        spawner.Spawn();
    }

    public int RemainingPlayers()
    {
        return players.Count;
    }

    private IEnumerator RunEndOfMatchSequence()
    {
        ui.EnableEndGameText();
        yield return new WaitForSeconds(4.0f);
        Game.instance.LoadScene("02 - SelectionMenu");
    }
}
