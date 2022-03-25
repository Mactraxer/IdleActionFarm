using UnityEngine;

public interface IMoveable
{
    public Vector3 GetPosition { get; }
    public void SetPosition(Vector3 newVector);
    public void ChangeParent(Transform parent);
}
