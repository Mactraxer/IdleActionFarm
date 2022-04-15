using DG.Tweening;
using UnityEngine;

public class GrassAnimator : MonoBehaviour
{

    [SerializeField] private GameObject _firstPart;
    [SerializeField] private GameObject _secondPart;

    private float _animateTime = 1f;

    void Start()
    {
        AnimateFirstPart();
        AnimateSecondPart();
    }

    private void AnimateFirstPart()
    {
        var sequence = DOTween.Sequence();

        Vector3 newAngle = _firstPart.transform.rotation.eulerAngles + Vector3.left;
        sequence.Append(_firstPart.transform.DORotate(newAngle, _animateTime));
        sequence.Append(_firstPart.transform.DOMoveY(0, _animateTime));
    }

    private void AnimateSecondPart()
    {
        var sequence = DOTween.Sequence();

        Vector3 newAngle = _firstPart.transform.rotation.eulerAngles + Vector3.left;
        sequence.Append(_secondPart.transform.DORotate(newAngle, _animateTime));
        sequence.Append(_secondPart.transform.DOMoveY(0, _animateTime));
    }
}
