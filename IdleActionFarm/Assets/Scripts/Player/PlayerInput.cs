using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public Action<float> OnInputHorizontal;
    public Action<float> OnInputVertical;
    public Action OnInputAction;

    private float _horizontalDirection;
    private float _verticalDirection;

    private const string HORIZONTAL_AXIS_NAME = "Horizontal";
    private const string VERTICAL_AXIS_NAME = "Vertical";

    private void Start()
    {
        _horizontalDirection = 0f;
        _verticalDirection = 0f;
    }

    private void FixedUpdate()
    {
        _horizontalDirection = Input.GetAxis(HORIZONTAL_AXIS_NAME);
        _verticalDirection = Input.GetAxis(VERTICAL_AXIS_NAME);

        OnInputHorizontal?.Invoke(_horizontalDirection);
        OnInputVertical?.Invoke(_verticalDirection);

        if (Input.GetKey(KeyCode.E))
        {
            OnInputAction?.Invoke();
        }
    }

}
