using System;
using System.Collections.Generic;

class SeedbedCircleStatus
{

    private List<SeedbedCircleConfig> _configPool;
    private SeedbedCircleConfig _currentConfig;

    public SeedbedCircleStatus(List<SeedbedCircleConfig> configs)
    {
        _configPool = new List<SeedbedCircleConfig>(configs);
        if (configs.Count < 1)
        {
            throw new InvalidOperationException("Failure init SeedCicleStatus because configs count < 1");
        }
        else
        {
            _currentConfig = configs[0];
        }

    }

    public void NextSeedbedCircle()
    {
        int nextConfigIndex = _configPool.IndexOf(_currentConfig) + 1;

        if (nextConfigIndex > _configPool.Count)
        {
            _currentConfig = _configPool[0];
        }
        else
        {
            _currentConfig = _configPool[nextConfigIndex];
        }

    }

    public float TimeForSeedbedCircle => _currentConfig.TimeForCircle;
    public SeedbedCircleType StatusType => _currentConfig.Status;

}
