using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourcePackMover))]
public class InventoryPresenter : MonoBehaviour
{
    private IMoverable _packMover;
    [SerializeField] private List<IResourceable> _items;
    [SerializeField] private Transform _inventoryTransform;
    [SerializeField] private int _maxInventoryCapacity;
    [SerializeField] private InventoryView _view;
    [SerializeField] private InventoryRotator _inventoryAnimator;
    

    private void Start()
    {
        _items = new List<IResourceable>();
        _packMover = GetComponent<ResourcePackMover>();

        _packMover.OnMovedPack += ResourceMoved;
        _packMover.Setup(_inventoryTransform, new Vector3(0, 0.2f, 0), 0.4f);

        _view.SetupInventoryView(_maxInventoryCapacity);
    }

    private void ResourceMoved(IMoveable pack)
    {
        IResourceable resource = (IResourceable)pack;
        if (resource == null) throw new ArgumentNullException("Can't convert IMoveable to IResourceable"); 

        _items.Add(resource);
        _view.UpdateInventoryView(_items.Count);
        pack.ChangeParent(_inventoryTransform);
        
    }

    /// API
    public void RotateInventory(float direction)
    {
        _inventoryAnimator.ChangeSpeed(direction);
    }

    public void PutItem(IResourceable item)
    {
        if (CanPutItem() == false) { throw new InvalidOperationException("Inventory is full"); }

        IMoveable resource = (IMoveable)item;
        if (resource == null) throw new ArgumentNullException("Can't convert IResourceable to IMoveable");
        _packMover.Move(resource);
    }

    public bool CanPutItem()
    {
        if (_items.Count + 1 > _maxInventoryCapacity)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public int InventoryCapacity => _items.Count;

    public List<IResourceable> GetResources()
    {
        return _items;
    }

    public void ClearInventory()
    {
        _items.ForEach( item => item.DestroySelf() );

        _items = new List<IResourceable>();
        _view.UpdateInventoryView(_items.Count);
        _packMover.ClearOffset();
    }

}
