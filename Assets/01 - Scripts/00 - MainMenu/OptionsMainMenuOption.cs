using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMainMenuOption : MenuOption
{
    public override void Select()
    {
        AudioManager.instance.PlayFromLibrary(AudioLibrary.SoundTag.Select);
        Game.instance.LoadScene("01 - OptionsMenu");
    }
}
