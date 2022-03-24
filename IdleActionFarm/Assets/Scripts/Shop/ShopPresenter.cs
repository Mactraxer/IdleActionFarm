using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(ShopTrigger))]
[RequireComponent(typeof(ResourcePackMover))]
public class ShopPresenter : MonoBehaviour
{
    [SerializeField] private Transform _shopPosition;
    private ShopTrigger _trigger;
    private IMoveable _resourceMover;
    private PlayerPresenter _playerPresenter;

    private void Start()
    {
        _trigger = GetComponent<ShopTrigger>();
        _resourceMover = GetComponent<ResourcePackMover>();

        _trigger.OnDetectInventory += DetectPlayer;
        _resourceMover.OnMovedPacks += MovedPacks;

        _resourceMover.Setup(_shopPosition, Vector3.zero, 0.2f);
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
        List<GameObject> resourceGameObjects = new List<GameObject>();
        resourcesForSell.ForEach(item => resourceGameObjects.Add(item.gameObject));

        _resourceMover.MovePacks(resourceGameObjects);
    }

    private void MovedPacks()
    {
        int payValue = 0;

        var resourcesForSell = _playerPresenter.BuyResources();
        resourcesForSell.ForEach(item => payValue += item.SellPrice);


        _playerPresenter.ApplyPay(payValue);
        _playerPresenter = null;
    }

}
