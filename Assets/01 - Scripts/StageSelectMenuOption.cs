using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectMenuOption : MenuOption
{
    public Stages stage;

    public override void Select()
    {
        switch (stage)
        {
            case Stages.StreetsOfShopville:
                Game.instance.LoadScene("03 - StreetsOfShopville");
                break;
            case Stages.ShopvilleSlums:
                Game.instance.LoadScene("04 - ShopvilleSlums");
                break;
        }
    }

    public enum Stages
    {
        StreetsOfShopville,
        ShopvilleSlums
    }
}
