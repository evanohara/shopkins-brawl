using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColors : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Color lightColor;
    [SerializeField]
    private Color darkColor;
    [SerializeField]
    private int lightColorsRedValue;
    [SerializeField]
    private int darksColorsRedValue;
#pragma warning restore 0649

    public Color LightColor { get => lightColor; }
    public Color DarkColor { get => darkColor; }
    public int LightColorsRedValue { get => lightColorsRedValue; }
    public int DarkColorsRedValue { get => darksColorsRedValue; }
}
