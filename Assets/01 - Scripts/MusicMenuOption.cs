using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicMenuOption : MenuOption
{
    public TextMeshProUGUI text;

    public override void Select()
    {
        AudioManager.instance.ToggleMusic();
        SetUIText();
    }

    private void SetUIText()
    {
        if (AudioManager.instance.MusicEnabled)
            text.text = "Music : On";
        else
            text.text = "Music : Off";
    }

}
