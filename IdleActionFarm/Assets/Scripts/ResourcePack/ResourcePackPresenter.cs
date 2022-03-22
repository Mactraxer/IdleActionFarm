using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePackPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _item;
    [SerializeField] private float _timeForAnimate;
    [SerializeField] private AnimationCurve _curve;
    private float _currentTime;

    private void Start()
    {
        _currentTime = 0f;
        StartCoroutine(CoroutineAnimateDrop(_item));
    }

    private void AnimateDrop()
    {

    }

    private void AnimateIdle()
    {

    }

    private IEnumerator CoroutineAnimateDrop(GameObject item)
    {

        var endPositionVector = new Vector3(item.transform.position.x, 2f, item.transform.position.z);

        var startPosition = item.transform.position;
        

        while (item.transform.position != endPositionVector)
        {
            var newPosition = Vector3.Lerp(startPosition, endPositionVector, _currentTime / _timeForAnimate);
            
            item.transform.position = newPosition;
            yield return null;
            _currentTime += Time.deltaTime;
        }

        _currentTime = 0f;
        endPositionVector = new Vector3(item.transform.position.x, 0.1f, item.transform.position.z);
        startPosition = item.transform.position;

        while (item.transform.position != endPositionVector)
        {
            var newPosition = Vector3.Lerp(startPosition, endPositionVector, _currentTime / _timeForAnimate * 2);
            
            item.transform.position = newPosition;
            yield return null;
            _currentTime += Time.deltaTime;
        }


    }

    private IEnumerator CoroutineAnimateIdle()
    {
        yield return null;
    }

}
