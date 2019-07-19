using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<Item> spawnableItems;



    public void SpawnItem(Vector2 position)
    {
        Item item = spawnableItems[Random.Range(0, spawnableItems.Count)];

        Instantiate<Item>(item, position, Quaternion.identity);
    }
}
