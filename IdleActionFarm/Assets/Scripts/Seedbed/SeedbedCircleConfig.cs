using UnityEngine;

[CreateAssetMenu(fileName = "new seedbedCircleConfig", menuName = "ScriptableObjects/SeedbedCircleConfig")]
class SeedbedCircleConfig : ScriptableObject
{
    [SerializeField] private SeedbedCircleType _status;
    [SerializeField] private float _timeForCircle;

    public SeedbedCircleType Status => _status;
    public float TimeForCircle => _timeForCircle;
}
