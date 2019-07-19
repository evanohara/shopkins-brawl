using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioLibrary;

public class TestHelper : MonoBehaviour
{
    public Canvas canvas;
    public TestInjector testInjector;
    public TestVariableExposer testVariableExposer;
    public AudioClip lead, main;

    void Awake()
    {
        if (!Game.instance.TestModeOn)
            Destroy(this);

        //AudioManager.instance.PlayMusicWithLead(lead, main);
    }

    public void UpdateTestCanvasCamTarget(Camera camera)
    {
        canvas.worldCamera = camera;
    }
}
