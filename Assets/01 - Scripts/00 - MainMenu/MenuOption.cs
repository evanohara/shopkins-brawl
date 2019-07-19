using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuOption : MonoBehaviour, ISelectable
{
    public MenuOption nextOption;
    public MenuOption prevOption;
    public RectTransform cursorSelectionTarget;

    public abstract void Select();
}
