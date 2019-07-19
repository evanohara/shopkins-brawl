using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInput;

public class PlayerController : MonoBehaviour
{
    public int playerNumber;

    private PlayerInput input;

    protected virtual void Awake()
    {
        if (input == null)
        {
            input = gameObject.AddComponent<PlayerInput>();
            input.AssignController(playerNumber);
        }
    }
    public bool ButtonJustPressed(Button button)
    {
        return input.ButtonJustPressed(button);
    }

    public bool ButtonDown(Button button)
    {
        return input.ButtonDown(button);
    }

    public float GetHorizontal()
    {
        return input.GetHorizontal();
    }

    public float GetVertical()
    {
        return input.GetVertical();
    }

    public Direction GetMajorDirection()
    {
        return input.GetMajorDirection();
    }
}
