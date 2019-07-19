using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private string xAxis;
    private string yAxis;
    private string startButton;
    private string bButton;
    private string aButton;
    private int joyNumber;

    public void AssignController(int number)
    {
        joyNumber = number;
        xAxis = "Joy" + joyNumber + "X";
        yAxis = "Joy" + joyNumber + "Y";
        startButton = "Joy" + joyNumber + "Start";
        bButton = "Joy" + joyNumber + "B";
        aButton = "Joy" + joyNumber + "A";
    }

    public enum Button
    {
        Start,
        B,
        A
    }

    public bool ButtonJustPressed(Button button)
    {
        switch (button)
        {
            case Button.Start:
                return Input.GetButtonDown(startButton);
            case Button.B:
                return Input.GetButtonDown(bButton);
            case Button.A:
                return Input.GetButtonDown(aButton);
            default:
                return false;
        }
    }

    public bool ButtonDown(Button button)
    {
        switch (button)
        {
            case Button.Start:
                return Input.GetButton(startButton);
            case Button.B:
                return Input.GetButton(bButton);
            case Button.A:
                return Input.GetButton(aButton);
            default:
                return false;
        }
    }

    public float GetHorizontal()
    {
        return Input.GetAxis(xAxis);
    }

    public float GetVertical()
    {
        return Input.GetAxis(yAxis);
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    public Direction GetMajorDirection()
    {
        float x = GetHorizontal();
        float y = GetVertical();

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x > 0)
            {
                return Direction.Right;
            }
            else if (x < 0)
            {
                return Direction.Left;
            }
        }
        else
        {
            if (y > 0)
            {
                return Direction.Up;
            }
            else if (y < 0)
            {
                return Direction.Down;
            }
        }

        return Direction.Up;
    }
}
