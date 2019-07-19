using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestVariableExposer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public ShopkinBaseCharacter _target;

    public void SetTarget(ShopkinBaseCharacter target)
    {
        _target = target;
    }

    void Update()
    {
        if (_target)
            UpdateUIText();
    }

    void UpdateUIText()
    {
        transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y + 1);
        text.text = "Velocity: " + _target.GetComponent<Rigidbody2D>().velocity.x.ToString("F2");
    }


}
