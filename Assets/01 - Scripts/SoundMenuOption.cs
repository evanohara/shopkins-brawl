using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundMenuOption : MenuOption
{
    public TextMeshProUGUI text;

    public override void Select()
    {
        AudioManager.instance.PlayFromLibrary(AudioLibrary.SoundTag.Select);
        AudioManager.instance.ToggleSound();
        SetUIText();
    }

    private void SetUIText()
    {
        if (AudioManager.instance.SoundEnabled)
            text.text = "Sound : On";
        else
            text.text = "Sound : Off";
    }

}
