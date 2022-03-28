using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class CoinAnimator : MonoBehaviour
{

    [SerializeField] private Sprite _coinSprite;
    [SerializeField] private RectTransform _distanse;
    [SerializeField] private float _durationTime;

    public void StartAnimation(int count)
    {

    }

    private IEnumerator CoroutineMoveCoin()
    {
        var waitFixedUpdate = new WaitForFixedUpdate();
        float time = 0;

        while (time < _durationTime)
        {
            //TODO - make coin animation
            yield return waitFixedUpdate;
        }
    }
}
