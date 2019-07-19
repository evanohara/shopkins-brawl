using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInput;

public class PlayerCharacterController : PlayerController
{
    private PlayerPainter playerPainter;
    private ShopkinBaseCharacter _character = null;

    protected override void Awake()
    {
        base.Awake();
        if (playerPainter == null)
            playerPainter = gameObject.GetComponent<PlayerPainter>();
    }

    public bool IsTryingToMove()
    {
        return (GetHorizontal() > 0.12f || GetHorizontal() < -0.12f);
    }

    public ShopkinBaseCharacter GetShopkin()
    {
        return _character;
    }

    public void SetShopkin(ShopkinBaseCharacter character)
    {
        _character = character;
        _character.player = this;
        playerPainter.SetCharacterToPaint(_character);
        playerPainter.PaintPlayer(this);
    }
}
