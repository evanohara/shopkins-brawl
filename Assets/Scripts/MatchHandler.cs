using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchHandler : MonoBehaviour
{
    public List<PlayerSpawner> playerSpawners;
    List<Player> players;

    void Start()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("ActivePlayer");
        players = new List<Player>();
        foreach (GameObject playerObject in playerObjects)
        {
            players.Add(playerObject.GetComponent<Player>());
        }

        InstantiatePlayerCharacters();
        SpawnPlayers();
    }

    void InstantiatePlayerCharacters()
    {
        foreach (Player p in players)
        {
            p.InstantiateCharacter();
        }
    }

    void SpawnPlayers()
    {
        Debug.Log(name + ": Spawning Players.");
        List<PlayerSpawner> unusedSpawners = new List<PlayerSpawner>();

        foreach (PlayerSpawner spawner in playerSpawners)
        {
            unusedSpawners.Add(spawner);
        }

        foreach (Player p in players)
        {
            int remainingUnusedSpawners = unusedSpawners.Count;
            int randomSpawnIndex = Random.Range(0, remainingUnusedSpawners);
            PlayerSpawner spawner = unusedSpawners[randomSpawnIndex];
            unusedSpawners.Remove(spawner);
            spawner.SetSpawnObject(p.GetShopkin().gameObject);
            spawner.Spawn();
        }
    }
}
