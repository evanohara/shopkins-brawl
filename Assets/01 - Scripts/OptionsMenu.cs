using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : Menu
{
    protected override void Update()
    {
        base.Update();
        CheckGoBackMainMenu();
    }
    private void CheckGoBackMainMenu()
    {
        if (Input.GetButtonDown("AnyA"))
            Game.instance.LoadScene("01 - MainMenu");
    }

}
