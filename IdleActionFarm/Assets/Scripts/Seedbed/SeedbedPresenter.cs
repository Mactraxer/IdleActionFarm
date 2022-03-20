using System;
using UnityEngine;

public class SeedbedPresenter : MonoBehaviour
{

    [SerializeField] private GameObject _grassNone;
    [SerializeField] private GameObject _grassYoung;
    [SerializeField] private GameObject _grassMature;

    [SerializeField] private SeedbedCircle _seedbedCircle;
    [SerializeField] private GameObject _seedbedGameObject;
    private GameObject _instiatedGrass;

    private void Awake()
    {
        _seedbedCircle.OnChangeStatus += SeedbedCircleStatusChanged;
    }

    private void SeedbedCircleStatusChanged(SeedbedCircleType type)
    {
        switch (type) 
        {
            case SeedbedCircleType.empty:
                Destroy(_instiatedGrass);
                _instiatedGrass = Instantiate(_grassNone, _seedbedGameObject.transform);
                break;
            case SeedbedCircleType.yound:
                Destroy(_instiatedGrass);
                _instiatedGrass = Instantiate(_grassYoung, _seedbedGameObject.transform);
                break;
            case SeedbedCircleType.mature:
                Destroy(_instiatedGrass);
                _instiatedGrass = Instantiate(_grassMature, _seedbedGameObject.transform);
                break;
            default:
                throw new ArgumentOutOfRangeException($"Not define logic for {type} in switch");
        }


    }

}
