using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private bool canMove = true;
    private Timer canMoveTimer;
    public MenuOption selectedOption;

    public List<MenuOption> options;
    public MenuUI UI;

    protected void Awake()
    {
        if (canMoveTimer == null)
        {
            canMoveTimer = gameObject.AddComponent<Timer>();
            canMoveTimer.SetAndStart(0.5f);
        }
    }

    protected virtual void Update()
    {
        if (canMoveTimer.Triggered())
        {
            canMove = true;
            canMoveTimer.ResetAndStart();
        }

        if (canMove)
        {
            if (Input.GetAxis("AnyY") > 0.1f)
            {
                ChangeSelection(selectedOption.prevOption);
            }
            else if (Input.GetAxis("AnyY") < -0.1f)
            {
                ChangeSelection(selectedOption.nextOption);
            }

        }
        if (Input.GetButtonDown("AnyB"))
        {
            selectedOption.Select();
        }
    }

    protected void ChangeSelection(MenuOption option)
    {
        selectedOption = option;
        UI.MoveCurrentSelectionCursor(option.cursorSelectionTarget);
        AudioManager.instance.PlayFromLibrary(AudioLibrary.SoundTag.MenuMove);
        canMove = false;
    }

}
