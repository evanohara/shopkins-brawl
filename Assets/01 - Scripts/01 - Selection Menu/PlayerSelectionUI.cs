using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionUI : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Awake()
    {
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();
    }

    internal void ChangeToSelectedCharacter(SelectableCharacter character)
    {
        //Debug.Log(this.name + ": Changing to selected character - " + character.name);
        sr.sprite = character.GetComponent<SpriteRenderer>().sprite;
    }
}
