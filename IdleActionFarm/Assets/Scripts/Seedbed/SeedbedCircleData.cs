
public struct SeedbedCircleData
{
    private string _name;
    private float _circleTime;

    public SeedbedCircleData(string name, float circleTime)
    {
        _name = name;
        _circleTime = circleTime;
    }

    public string Name => _name;
    public float CircleTime => _circleTime;

}
