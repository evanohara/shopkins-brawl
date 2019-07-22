using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float? _maxTime;
    private float _timeRemaining;
    private bool _triggered = false;

    public bool Paused { get; set; } = true;

    private void Update()
    {
        if (!Paused)
        {
            _timeRemaining -= Time.deltaTime;
            if (_timeRemaining < 0f)
            {
                _triggered = true;
                Paused = true;
            }
        }

    }

    public void SetAndStart(float time)
    {
        _maxTime = time;
        _timeRemaining = time;
        Start();
    }

    public float GetRemainingTime()
    {
        return _timeRemaining;
    }

    private void Start()
    {
        Paused = false;
    }
    public void ResetAndStart()
    {
        if (_maxTime == null)
            Debug.Log("Timer never set.");
        else
        {
            _triggered = false;
            _timeRemaining = (float)_maxTime;
            Start();
        }
    }

    public bool Triggered()
    {
        return _triggered;
    }

}
