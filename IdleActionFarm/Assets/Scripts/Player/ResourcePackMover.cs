using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ResourcePackMover : MonoBehaviour, IMoverable
{

    private Transform _distanse;
    private Vector3 _currentPositionOffset;
    private Vector3 _positionOffsetStep;
    private float _speed;

    private void Start()
    {
        _currentPositionOffset = Vector3.zero;
    }

    private IEnumerator CoroutineMove(IMoveable item)
    {
        var waitForFixedUpdate = new WaitForFixedUpdate();

        while (item.GetPosition != _distanse.position + _currentPositionOffset)
        {
            Vector3 newPosition = Vector3.MoveTowards(item.GetPosition, _distanse.position + _currentPositionOffset, _speed);
            item.SetPosition(newPosition);
            yield return waitForFixedUpdate;
        }

        OnMovedPack?.Invoke(item);
        SetNextPosition();
    }

    private IEnumerator CoroutineMove(List<IMoveable> items)
    {
        var waitForFixedUpdate = new WaitForFixedUpdate();

        foreach (var item in items)
        {
            yield return StartCoroutine(CoroutineMove(item));
        }

        OnMovedPacks?.Invoke();
    }

    private void SetNextPosition()
    {
        _currentPositionOffset += _positionOffsetStep;
    }

    ///
    /// IMoveable 
    ///

    public Action<IMoveable> OnMovedPack { get; set; }
    public Action OnMovedPacks { get; set; }

    public void Setup(Transform distanse, Vector3 positionOffsetStep, float speed)
    {
        _distanse = distanse;
        _positionOffsetStep = positionOffsetStep;
        _speed = speed;
    }

    public void Move(IMoveable pack)
    {
        StartCoroutine(CoroutineMove(pack));
    }

    public void Move(List<IMoveable> packs)
    {
        StartCoroutine(CoroutineMove(packs));
    }

    public void ClearOffset()
    {
        _currentPositionOffset = Vector3.zero;
    }

}
