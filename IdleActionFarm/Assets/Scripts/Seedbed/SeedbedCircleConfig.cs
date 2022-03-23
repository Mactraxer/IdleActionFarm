using UnityEngine;

[CreateAssetMenu(fileName = "SeedbedCircleConfig", menuName = "ScriptableObjects/New SeedbedCircleConfig")]
class SeedbedCircleConfig : ScriptableObject
{

    [SerializeField] private string _name;
    [SerializeField] private bool _isRipe;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _timeForCircle;

    public string Name => _name;
    public GameObject Prefab => _prefab;
    public float TimeForCircle => _timeForCircle;
    public bool IsRipe => _isRipe;
    
}
