using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CoinTextAnimator : MonoBehaviour
{
    private Text _text;

    public void InitComponent(Text text)
    {
        _text = text;
    }

    public void StartAnimation(int toValue)
    {
        Sequence sequence = DOTween.Sequence();
        
        sequence.Append(_text.DOText($"{toValue}", 1f, true, ScrambleMode.Numerals));
    }

}
