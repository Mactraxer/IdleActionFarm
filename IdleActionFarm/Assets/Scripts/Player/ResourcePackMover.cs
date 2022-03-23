using UnityEngine;
using System.Collections;
using System;

public class ResourcePackMover : MonoBehaviour
{

    [SerializeField] private Transform _transformDistanse;
    private Vector3 _positionOffset;
    [SerializeField] private float _speed;
    public Action<GameObject> OnMoved;

    private void Start()
    {
        _positionOffset = Vector3.zero;
    }

    public void MovePack(GameObject pack)
    {
        StartCoroutine(CoroutineMove(pack));
    }

    private IEnumerator CoroutineMove(GameObject item)
    {
        var waitForFixedUpdate = new WaitForFixedUpdate();
        
        while (item.transform.position != _transformDistanse.position + _positionOffset)
        {
            item.transform.position = Vector3.MoveTowards(item.transform.position, _transformDistanse.position + _positionOffset, _speed);
            yield return waitForFixedUpdate;
        }
        
        OnMoved?.Invoke(item);
        SetNextPosition();
    }

    
    private void SetNextPosition()
    {
        _positionOffset += new Vector3(0, 0.2f, 0);
    }

}
