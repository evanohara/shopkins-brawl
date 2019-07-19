using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CameraZoomer : MonoBehaviour
{
    float targetX = 0;
    Timer transitionTimer;
    public float timePerTick;
    public PixelPerfectCamera ppCam;
    private int targetPixelsPerUnit = 32;

    void Awake()
    {
        if (transitionTimer == null)
            transitionTimer = gameObject.AddComponent<Timer>();
        transitionTimer.SetAndStart(timePerTick);
    }

    // Update is called once per frame
    void Update()
    {
        targetX = CalculateHorizontalMidwayBetweenAllPlayers();


        float maxDistance = CalculateMaxDistanceBetweenPlayers();
        if (maxDistance < 12F)
        {
            targetPixelsPerUnit = 32;
        }
        else if (maxDistance < 16f)
        {
            targetPixelsPerUnit = 24;
        }
        else if (maxDistance < 24F)
        {
            targetPixelsPerUnit = 16;
        }
        else
        {
            targetX = 0;
            targetPixelsPerUnit = 8;
        }

        gameObject.transform.position = new Vector3(targetX, transform.position.y, transform.position.z);

        if (targetPixelsPerUnit > ppCam.assetsPPU)
        {
            if (transitionTimer.Triggered())
            {
                ppCam.assetsPPU++;
                transitionTimer.ResetAndStart();
            }
        }
        else if (targetPixelsPerUnit < ppCam.assetsPPU)
        {
            if (transitionTimer.Triggered())
            {
                ppCam.assetsPPU--;
                transitionTimer.ResetAndStart();
            }
        }
    }

    float CalculateHorizontalMidwayBetweenAllPlayers()
    {
        List<PlayerCharacterController> players = Match.instance.activePlayers;
        float totalXValue = 0f;
        foreach (PlayerCharacterController player in players)
        {
            totalXValue += player.GetShopkin().transform.position.x;
        }
        return totalXValue / players.Count;
    }

    float CalculateMaxDistanceBetweenPlayers()
    {
        List<PlayerCharacterController> players = Match.instance.activePlayers;
        float minXDistance = players[0].GetShopkin().transform.position.x;
        float maxXDistance = minXDistance;

        foreach (PlayerCharacterController player in players)
        {
            float x = player.GetShopkin().transform.position.x;

            if (x > maxXDistance)
                maxXDistance = x;
            else if (x < minXDistance)
                minXDistance = x;

        }

        return maxXDistance - minXDistance;
    }
}
