using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingEffect : Effect
{
    private readonly float _blinkTime = 0.1f;
    private Timer _singleBlinkToggleTimer;
    private bool _invisEffectOn = false;

    protected override void StartEffectEx()
    {
        _singleBlinkToggleTimer = gameObject.AddComponent<Timer>();
        _singleBlinkToggleTimer.SetAndStart(_blinkTime);
    }

    protected override void UpdateEx()
    {
        if (_singleBlinkToggleTimer.Triggered())
        {
            ToggleBlink();
            _singleBlinkToggleTimer.ResetAndStart();
        }
    }

    protected override void EndEffectEx()
    {
        _sr.color = Color.white;
    }


    private void ToggleBlink()
    {
        if (_invisEffectOn)
        {
            _sr.color = Color.white;
            _invisEffectOn = false;
        }
        else
        {
            _sr.color = Color.clear;
            _invisEffectOn = true;
        }
    }


}
