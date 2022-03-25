using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourcePackMover))]
public class PlayerInventory : MonoBehaviour
{
    private IMoverable _packMover;
    [SerializeField] private List<IResourceable> _items;
    [SerializeField] private Transform _inventoryTransform;
    [SerializeField] private int _maxInventoryCapacity;

    private void Start()
    {
        _items = new List<IResourceable>();
        _packMover = GetComponent<ResourcePackMover>();

        _packMover.OnMovedPack += ResourceMoved;
        _packMover.Setup(_inventoryTransform, new Vector3(0, 0.2f, 0), 0.2f);
    }

    private void ResourceMoved(IMoveable pack)
    {
        IResourceable resource = (IResourceable)pack;
        if (resource == null) throw new ArgumentNullException("Can't convert IMoveable to IResourceable"); 

        _items.Add(resource);
        pack.ChangeParent(_inventoryTransform);
        
    }

    /// API
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
        _packMover.ClearOffset();
    }

}
