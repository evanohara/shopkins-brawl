using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTester : MonoBehaviour
{
    public AudioClip sound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("TestButton"))
            AudioManager.instance.PlaySingle(sound);
    }
}
