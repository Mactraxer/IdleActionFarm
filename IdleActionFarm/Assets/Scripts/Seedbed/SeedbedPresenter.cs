using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(SeedbedTrigger))]
public class SeedbedPresenter : MonoBehaviour
{

    [SerializeField] private List<SeedbedCircleConfig> _configs;
    private SeedbedCircleConfig _currentConfig;
    private SeedbedTrigger _trigger;

    private GameObject _instantiatedObject;

    private Timer _timer; 

    private void Awake()
    {
        InitComponents();

        _timer.OnTimeout += Timeout;
        _trigger.OnDetectTool += DetectTool;
    }

    private void OnDisable()
    {
        _timer.OnTimeout -= Timeout;
    }

    private void Start()
    {
        ResetSeedbedCircle();
    }

    private void InitComponents()
    {
        _timer = GetComponent<Timer>();
        _trigger = GetComponent<SeedbedTrigger>();
    }

    private void Timeout()
    {
        SetNextConfig();
        InstantiateObject();
    }

    private void DetectTool()
    {
        print(_currentConfig);
        if (_currentConfig.IsRipe == true)
        {
            ResetSeedbedCircle();
        }
        
    }

    private void InstantiateObject()
    {
        if (_instantiatedObject != null)
        {
            Destroy(_instantiatedObject);
        }
        _instantiatedObject = Instantiate(_currentConfig.Prefab, transform);
    }

    private void SetNextConfig()
    {
        var nextIndexConfig = _configs.IndexOf(_currentConfig) + 1;

        if (nextIndexConfig < _configs.Count)
        {
            _currentConfig = _configs[nextIndexConfig];
            StartSeedbedCircle();
        }

    }

    private void ResetSeedbedCircle()
    {
        _currentConfig = _configs[0];
        StartSeedbedCircle();
        InstantiateObject();
    }
    
    private void StartSeedbedCircle()
    {
        _timer.StartTimer(_currentConfig.TimeForCircle);
    }

}
