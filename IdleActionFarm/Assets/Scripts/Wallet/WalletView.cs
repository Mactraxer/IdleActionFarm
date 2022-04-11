using System;
using UnityEngine;
using UnityEngine.UI;

public class WalletView : MonoBehaviour
{

    [SerializeField] private Text _goldTextValue;
    [SerializeField] private CoinTextAnimator _animator;

    private void Start()
    {
        _animator.InitComponent(_goldTextValue);    
    }

    public void UpdateView(int value)
    {
        _animator.StartAnimation(value);
        //_goldValue.text = $"{value}";
    }

}
