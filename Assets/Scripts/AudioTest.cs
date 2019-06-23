using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioClip clip;
    public AudioClip lead;
    public AudioClip mainMusic;

    void Update()
    {
        if (Input.GetButtonDown("Joy1B"))
        {
            AudioManager.instance.PlaySingle(clip);
        }

        if (Input.GetButtonDown("Joy1Select"))
        {
            AudioManager.instance.PlayMusicWithLead(lead, mainMusic);
        }
    }
}
