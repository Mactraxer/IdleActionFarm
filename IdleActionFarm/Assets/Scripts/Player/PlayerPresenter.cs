using UnityEngine;
using System.Collections.Generic;

public class PlayerPresenter : MonoBehaviour
{

    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerAnimator _animator;

    [SerializeField] private InventoryPresenter _inventory;
    [SerializeField] private WalletPresenter _walletPresenter;

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

    private void DetectResource(IResourceable resource)
    {
        if (_inventory.CanPutItem() == false) return;
        
        resource.ResourcePicked();
        _inventory.PutItem(resource);
    }

    private void InputVertical(float direction)
    {
        _mover.MoveVertical(direction);
        _animator.AnimateMove(direction);
        _inventory.RotateInventory(direction);
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

    private void DetectHarvestableObject(IHarvestable harvestableComponent)
    {
        if (harvestableComponent.IsRipe == false) return;

        _tool.SetActive(true);
        _animator.AnimateHarvesting();

    }

    private void LoseHarvestableObject()
    {
        _tool.SetActive(false);
        _animator.AnimateIdle();
    }

    /// API
    public List<IResourceable> BuyResources()
    {
        return _inventory.GetResources();
    }

    public bool HaveResourceForSell => _inventory.InventoryCapacity > 0;

    public void ApplyPay(int value)
    {
        _walletPresenter.TopUpWallet(value);
        _inventory.ClearInventory();
    }
    

}
