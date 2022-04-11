using UnityEngine;
using DG.Tweening;
using System;

public class CoinAnimator : MonoBehaviour
{

    [SerializeField] private Transform _distanse;
    [SerializeField] private float _durationTime;
    
    public Action<Transform> OnAnimationEnd;

    public void StartAnimation(Transform coin)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.OnKill(() => OnAnimationEnd?.Invoke(coin));
        sequence.Append(coin.DOMove(_distanse.transform.position, _durationTime)).SetEase(Ease.InQuad);
    }

}
