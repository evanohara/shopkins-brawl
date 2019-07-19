using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureModeMainMenuOption : MenuOption
{
    public override void Select()
    {
        AudioManager.instance.PlayFromLibrary(AudioLibrary.SoundTag.Buzz);
    }

}
