using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    GameObject spawnMe;

    internal void Spawn()
    {
        //Debug.Log(name + ": Spawning Object.");
        spawnMe.transform.position = transform.position;
    }

    internal void SetSpawnObject(GameObject thingToSpawn)
    {
        //Debug.Log(name + ": Setting Object to Spawn.");
        spawnMe = thingToSpawn;
    }
}
