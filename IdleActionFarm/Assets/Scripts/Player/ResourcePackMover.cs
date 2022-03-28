using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ResourcePackMover : MonoBehaviour, IMoverable
{

    private Transform _distanse;
    private Vector3 _currentPositionOffset;
    private Vector3 _positionOffsetStep;
    private float _timeDuration = .4f;

    private void Start()
    {
        _currentPositionOffset = Vector3.zero;
    }

    private IEnumerator CoroutineMove(IMoveable item)
    {
        var waitForFixedUpdate = new WaitForFixedUpdate();
        Vector3 startPosition = item.GetPosition;
        Quaternion startRotation = item.GetRotate;
        Vector3 startScale = item.GetScale;

        Vector3 newScale;
        Vector3 newPosition;
        Quaternion newRotate;

        float currentTime = 0f;

        while (currentTime < _timeDuration)
        {
            newPosition = Vector3.Lerp(startPosition, _distanse.position + _currentPositionOffset, currentTime / _timeDuration);
            newRotate = Quaternion.Lerp(startRotation, _distanse.rotation, currentTime / _timeDuration);
            newScale = Vector3.Lerp(startScale, _distanse.localScale, currentTime / _timeDuration);
            item.SetPosition(newPosition);
            item.SetRotate(newRotate);
            item.SetScale(newScale);
            currentTime += Time.deltaTime;
            yield return waitForFixedUpdate;
            
        }

        
        item.SetPosition(_distanse.position + _currentPositionOffset);
        item.SetRotate(_distanse.rotation);
        item.SetScale(_distanse.localScale);

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

    public void Setup(Transform distanse, Vector3 positionOffsetStep, float timeDuration)
    {
        _distanse = distanse;
        _positionOffsetStep = positionOffsetStep;
        _timeDuration = timeDuration;
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
