using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    [SerializeField] private Transform _startPosition;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform _parent;

    public GameObject SpawnCoin()
    {
        var instantiatedCoin = Instantiate(_coinPrefab, _startPosition.position, _parent.rotation, _parent);
        return instantiatedCoin;
    }

}
