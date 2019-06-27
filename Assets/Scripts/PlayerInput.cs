using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private string xAxis;
    private string yAxis;
    private string startButton;
    private string bButton;
    private int joyNumber;

    internal void AssignController(int number)
    {
        joyNumber = number;
        xAxis = "Joy" + joyNumber + "X";
        yAxis = "Joy" + joyNumber + "Y";
        startButton = "Joy" + joyNumber + "Start";
        bButton = "Joy" + joyNumber + "B";
    }

    public enum Button
    {
        Start,
        B
    }

    internal bool ButtonIsDown(Button button)
    {
        switch (button)
        {
            case Button.Start:
                return Input.GetButtonDown(startButton);
            case Button.B:
                return Input.GetButtonDown(bButton);
            default:
                return false;
        }
    }

    internal float GetHorizontal()
    {
        return Input.GetAxis(xAxis);
    }

    internal float GetVertical()
    {
        return Input.GetAxis(yAxis);
    }

    internal enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    internal Direction GetMajorDirection()
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
