using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndicator : MonoBehaviour
{
    SpriteRenderer sr;
    public List<Sprite> allIndicators;

    void Awake()
    {
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();
    }
    public void SetIndicator(int playerNumber)
    {
        sr.sprite = allIndicators[playerNumber - 1];
    }
}
