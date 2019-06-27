using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInput;

public class Player : MonoBehaviour
{
    public int playerNumber;

    private PlayerInput input;
    private ShopkinBaseCharacter _character;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (input == null)
            input = gameObject.AddComponent<PlayerInput>();
    }

    private void Start()
    {
        input.AssignController(playerNumber);
    }

    internal bool ButtonIsDown(Button button)
    {
        return input.ButtonIsDown(button);
    }

    internal float GetHorizontal()
    {
        return input.GetHorizontal();
    }

    internal float GetVertical()
    {
        return input.GetVertical();
    }

    internal Direction GetMajorDirection()
    {
        return input.GetMajorDirection();
    }

    internal void AssignCharacter(ShopkinBaseCharacter character)
    {
        Debug.Log(this.name + ": Assigning Character - " + character.name);
        _character = character;
    }

    internal ShopkinBaseCharacter GetShopkin()
    {
        return _character;
    }

    internal void InstantiateCharacter()
    {
        Instantiate(_character).player = this;
    }

}
