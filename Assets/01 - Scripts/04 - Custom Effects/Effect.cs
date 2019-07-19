using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    protected Timer _effectTimer;
    protected SpriteRenderer _sr;

    public void StartEffect(SpriteRenderer sr, float duration)
    {
        //Debug.Log("StartEffect");
        _sr = sr;
        _effectTimer = gameObject.AddComponent<Timer>();
        _effectTimer.SetAndStart(duration);
        StartEffectEx();
    }

    private void Update()
    {
        UpdateEx();
        if (_effectTimer.Triggered())
        {
            EndEffect();
        }
    }


    public void EndEffect()
    {
        EndEffectEx();
        Destroy(this);
    }

    protected abstract void StartEffectEx();
    protected abstract void UpdateEx();
    protected abstract void EndEffectEx();
}
