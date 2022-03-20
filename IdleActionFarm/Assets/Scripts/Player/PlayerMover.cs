using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    [SerializeField] private float _speed;

    public void MoveVertical(float direction)
    {
        var vectorDirection = new Vector3(0, 0, direction);
        transform.Translate(vectorDirection * _speed);
    }

    public void MoveHorizontal(float direction)
    {
        var vectorDirection = new Vector3(0, direction, 0);
        transform.RotateAround(transform.position, vectorDirection, 3f);
    }

}
