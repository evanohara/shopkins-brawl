using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantUpdateLogger : MonoBehaviour
{
    int a = 0;
    int totalUpdates = 0;
    float totalTime = 0f;
    int fixedUpdates = 0;
    int totalFixedUpdates = 0;

    void Awake()
    {
        StartCoroutine(LogUpdates());
    }
    // Update is called once per frame
    void Update()
    {
        a++;
    }

    void FixedUpdate()
    {
        fixedUpdates++;
    }

    public float GetAverageUpdatesPerSecond()
    {
        return totalUpdates / totalTime;
    }
    public float GetAverageFixedUpdatesPerSecond()
    {

        return totalFixedUpdates / totalTime;
    }

    IEnumerator LogUpdates()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log(a + " - Updates/Sec.  ## " + fixedUpdates + " - FUpdates/Sec", DLogType.Log);
        totalUpdates += a;
        totalFixedUpdates += fixedUpdates;
        totalTime += 1f;
        a = 0;
        fixedUpdates = 0;

        StartCoroutine(LogUpdates());
    }
}
