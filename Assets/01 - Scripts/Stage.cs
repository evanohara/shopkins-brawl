using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Transform LeftWall;
    public Transform RightWall;

    float itemSpawnTime = 20f;
    Timer timer;

    private void Awake()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.SetAndStart(itemSpawnTime);
    }

    private void Update()
    {
        if (timer.Triggered())
        {
            float horizontalSpawnLocation = Random.Range(LeftWall.position.x, RightWall.position.x);
            ItemSpawner.SpawnItem(new Vector2(horizontalSpawnLocation, 12f));
            timer.ResetAndStart();
        }

    }

    public ItemSpawner ItemSpawner;
}
