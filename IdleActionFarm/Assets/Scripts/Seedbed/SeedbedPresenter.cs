using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(SeedbedTrigger))]
public class SeedbedPresenter : MonoBehaviour, IHarvestable
{

    [SerializeField] private List<SeedbedCircleConfig> _configs;
    [SerializeField] private GameObject _resourceDrop;

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
        
        if (_currentConfig.IsRipe == true)
        {
            DropResource();
            ResetSeedbedCircle();
        }
        
    }

    private void DropResource()
    {
        Instantiate(_resourceDrop, transform.position, Quaternion.identity);
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
        _timer.StopTimer();
        _currentConfig = _configs[0];
        StartSeedbedCircle();
        InstantiateObject();
    }
    
    private void StartSeedbedCircle()
    {
        _timer.StartTimer(_currentConfig.TimeForCircle);
    }

    ///
    /// IHarvestable
    /// 

    public bool IsRipe => _currentConfig.IsRipe;
}
