using UnityEngine;

public class CoinPresenter : MonoBehaviour
{
    [SerializeField] private CoinSpawner _spawner;
    [SerializeField] private CoinAnimator _animator;

    private void Start()
    {
        _animator.OnAnimationEnd += AnimationEnd;
    }

    private void OnDisable()
    {
        _animator.OnAnimationEnd -= AnimationEnd;
    }

    public void AppearCoin()
    {
        var spawnedCoin = _spawner.SpawnCoin();
        _animator.StartAnimation(spawnedCoin.transform);
    }

    private void AnimationEnd(Transform coin)
    {
        Destroy(coin.gameObject);
    }

}
