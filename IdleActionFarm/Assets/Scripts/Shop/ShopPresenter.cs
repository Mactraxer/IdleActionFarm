using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(ShopTrigger))]
[RequireComponent(typeof(ResourcePackMover))]
public class ShopPresenter : MonoBehaviour
{
    [SerializeField] private Transform _shopPosition;
    private ShopTrigger _trigger;
    private IMoverable _resourceMover;
    private PlayerPresenter _playerPresenter;

    private int _sumForPay;

    private void Start()
    {
        _trigger = GetComponent<ShopTrigger>();
        _resourceMover = GetComponent<ResourcePackMover>();

        _trigger.OnDetectInventory += DetectPlayer;
        _resourceMover.OnMovedPacks += MovedPacks;

        _resourceMover.Setup(_shopPosition, Vector3.zero, 0.2f);

        _sumForPay = 0;
    }

    private void OnDisable()
    {
        _trigger.OnDetectInventory -= DetectPlayer;
        _resourceMover.OnMovedPacks -= MovedPacks;
    }

    private void DetectPlayer(PlayerPresenter presenter)
    {
        if (presenter.HaveResourceForSell == false) return;

        _playerPresenter = presenter;
        var resourcesForSell = presenter.BuyResources();

        List<IMoveable> resourcesMoveable = new List<IMoveable>();

        resourcesForSell.ForEach( item => resourcesMoveable.Add((IMoveable)item) );
        bool allResourcesNotNull = resourcesMoveable.TrueForAll(item => item != null);
        if (allResourcesNotNull == false) throw new ArgumentNullException("Object hasn't implemented interfaces: IMoveable, IResourceable");

        _resourceMover.Move(resourcesMoveable);
        CalculateSellPrice(resourcesForSell);
    }

    private void CalculateSellPrice(List<IResourceable> resources)
    {
        _sumForPay = 0;

        resources.ForEach(item => _sumForPay += item.GetResourceData().SellPrice);
    }

    private void MovedPacks()
    {
        _playerPresenter.ApplyPay(_sumForPay);
        _playerPresenter = null;
    }

}
