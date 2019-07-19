using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchUI : MonoBehaviour
{
    public List<TextMeshProUGUI> healthIndicators;
    public TextMeshProUGUI endGameText;

    public static MatchUI instance = null;


    public void EnableEndGameText()
    {
        endGameText.enabled = true;
    }

    public void UpdateHealthIndicator(int playerNumber, int health)
    {
        healthIndicators[playerNumber - 1].SetText(health.ToString());
    }
}
