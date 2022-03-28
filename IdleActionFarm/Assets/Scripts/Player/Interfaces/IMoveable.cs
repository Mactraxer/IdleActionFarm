using UnityEngine;

public interface IMoveable
{
    public Vector3 GetPosition { get; }
    public Quaternion GetRotate { get; }
    public Vector3 GetScale { get; }

    public void SetPosition(Vector3 newVector);
    public void SetRotate(Quaternion quaternion);
    public void SetScale(Vector3 scale);
    public void ChangeParent(Transform parent);
}
