using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Image cursor;
    public void MoveCurrentSelectionCursor(RectTransform moveToMe)
    {
        cursor.transform.position = moveToMe.position;
    }
}
