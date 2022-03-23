using UnityEngine;

public class PlayerPresenter : MonoBehaviour
{

    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private InventoryRotator _inventoryAnimator;

    [SerializeField] private HarvestTrigger _harvestTrigger;
    
    [SerializeField] private GameObject _tool;

    [SerializeField] private ResourcePackTrigger _resourceTrigger;


    private void Start()
    {
        _tool.SetActive(false);

        _input.OnInputHorizontal += InputHorizontal;
        _input.OnInputVertical += InputVertical;
        _input.OnInputAction += InputAction;

        _harvestTrigger.OnDetectHarvestableObject += DetectHarvestableObject;
        _harvestTrigger.OnLoseHarvestableObject += LoseHarvestableObject;

        _resourceTrigger.OnDetectResource += DetectResource;
    }

    private void OnDisable()
    {
        _input.OnInputHorizontal -= InputHorizontal;
        _input.OnInputVertical -= InputVertical;
        _input.OnInputAction -= InputAction;

        _harvestTrigger.OnDetectHarvestableObject -= DetectHarvestableObject;
        _harvestTrigger.OnLoseHarvestableObject -= LoseHarvestableObject;

        _resourceTrigger.OnDetectResource -= DetectResource;
    }



    private void DetectResource(ResourcePackData data)
    {
        ResourcePackPresenter resourcePresenter;
        if (data.gameObject.TryGetComponent(out resourcePresenter))
        {
            resourcePresenter.ResourcePicked();
        }

        _inventory.PutItem(data.gameObject);
    }

    private void InputVertical(float direction)
    {
        _mover.MoveVertical(direction);
        _animator.AnimateMove(direction);
        _inventoryAnimator.ChangeSpeed(direction);
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
        _tool.SetActive(true);
        _animator.AnimateHarvesting();
    }

    private void LoseHarvestableObject()
    {
        _tool.SetActive(false);
        _animator.AnimateIdle();
    }

}
