using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPainter : MonoBehaviour
{
    private Texture2D mColorSwapTex;
    private Color[] mSpriteColors;

#pragma warning disable 0649
    [SerializeField]
    private Color _lightColor;
    [SerializeField]
    private Color _darkColor;

#pragma warning restore 0649

    public Color LightColor { get => _lightColor; }
    public Color DarkColor { get => _darkColor; }

    private SpriteRenderer sr;

    private void InitColorSwapTex()
    {
        Texture2D colorSwapTex = new Texture2D(256, 1, TextureFormat.RGBA32, false, false);
        colorSwapTex.filterMode = FilterMode.Point;

        for (int i = 0; i < colorSwapTex.width; ++i)
            colorSwapTex.SetPixel(i, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f));

        colorSwapTex.Apply();

        sr.material.SetTexture("_SwapTex", colorSwapTex);

        mSpriteColors = new Color[colorSwapTex.width];
        mColorSwapTex = colorSwapTex;
    }

    public void SetCharacterToPaint(ShopkinBaseCharacter shopkin)
    {
        //Debug.Log("Called.");
        sr = shopkin.GetComponent<SpriteRenderer>();
        InitColorSwapTex();
    }

    public void PaintPlayer(PlayerCharacterController player)
    {
        CharacterColors characterColors = player.GetShopkin().GetComponent<CharacterColors>();
        mColorSwapTex.SetPixel(characterColors.LightColorsRedValue, 0, _lightColor);
        mColorSwapTex.SetPixel(characterColors.DarkColorsRedValue, 0, _darkColor);

        mColorSwapTex.Apply();
        //Debug.Log(name + ": Painting player.");
        //Debug.Log(name + ": Red Value of Light in character - " + characterColors.LightColorsRedValue + " is being replaced with: " + _lightColor.ToString());
        //Debug.Log(name + ": Red Value of Dark in character - " + characterColors.DarkColorsRedValue + " is being replaced with: " + _darkColor.ToString());
    }


    public void ResetAllSpritesColors()
    {
        for (int i = 0; i < mColorSwapTex.width; ++i)
            mColorSwapTex.SetPixel(i, 0, mSpriteColors[i]);
        mColorSwapTex.Apply();
    }
}
