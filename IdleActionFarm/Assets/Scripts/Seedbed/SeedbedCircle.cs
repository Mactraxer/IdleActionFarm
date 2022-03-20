using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

public class SeedbedCircle : MonoBehaviour, IHarvestable
{
    [SerializeField] private List<SeedbedCircleConfig> _configs;
    private SeedbedCircleStatus _status;

    public Action<SeedbedCircleType> OnChangeStatus;
    public bool TryChangeSeedbedCircle()
    {
        return _status.StatusType == SeedbedCircleType.mature;
    }

    public void ChangeSeedbedCircle()
    {
        if (TryChangeSeedbedCircle() == false) { throw new InvalidOperationException("Current seedbed circle status not allow change self by API"); }

        _status.NextSeedbedCircle();
    }

    private void Start()
    {
        _status = new SeedbedCircleStatus(_configs);
        print($"Status is {_status.StatusType}");
        OnChangeStatus.Invoke(_status.StatusType);
        StartCoroutine(CoroutineCirleTimer(_status.TimeForSeedbedCircle));
    }

    private IEnumerator CoroutineCirleTimer(float duration)
    {
        var waitForSeconds = new WaitForSeconds(1);
        float time = 0;

        while (duration != time)
        {
            time++;
            yield return waitForSeconds;
        }

        CircleTimeout();
    }

    private void CircleTimeout()
    {
        if (_status.StatusType != SeedbedCircleType.mature)
        {
            _status.NextSeedbedCircle();
            print($"StatusChanges on {_status.StatusType}");
            OnChangeStatus?.Invoke(_status.StatusType);
            StartCoroutine(CoroutineCirleTimer(_status.TimeForSeedbedCircle));
        }
    }

}

