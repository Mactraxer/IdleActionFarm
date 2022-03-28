using System.Collections;
using System;
using UnityEngine;

public class Timer: MonoBehaviour
{

    public Action OnTimeout;

    public void StartTimer(float duration)
    {
        StartCoroutine(CoroutineTimer(duration));
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }

    private IEnumerator CoroutineTimer(float duration)
    {
        var waitForSeconds = new WaitForSeconds(1);
        float time = 0;

        while (duration != time)
        {
            time++;
            yield return waitForSeconds;
        }

        OnTimeout?.Invoke();
    }

}

