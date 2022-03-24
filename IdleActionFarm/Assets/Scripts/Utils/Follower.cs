using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * _speed);        
    }

}
