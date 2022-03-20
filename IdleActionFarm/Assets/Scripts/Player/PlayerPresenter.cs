using UnityEngine;

public class PlayerPresenter : MonoBehaviour
{

    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private PlayerTrigger _trigger;

    private void Start()
    {
        _input.OnInputHorizontal += InputHorizontal;
        _input.OnInputVertical += InputVertical;
        _input.OnInputAction += InputAction;

        _trigger.OnDetectHarvestableObject += DetectHarvestableObject;
        _trigger.OnLoseHarvestableObject += LoseHarvestableObject;
    }

    private void InputVertical(float direction)
    {
        _mover.MoveVertical(direction);
        _animator.AnimateMove(direction);
    }

    private void InputHorizontal(float direction)
    {
        _mover.MoveHorizontal(direction);
        _animator.AnimateMove(direction);
    }

    private void InputAction()
    {
        _animator.AnimateHarvesting();
    }

    private void DetectHarvestableObject()
    {
        _animator.AnimateHarvesting();
    }

    private void LoseHarvestableObject()
    {
        _animator.AnimateIdle();
    }

}
