using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourcePackMover))]
public class PlayerInventory : MonoBehaviour
{
    private IMoveable _packMover;
    [SerializeField] private List<GameObject> _items;
    [SerializeField] private Transform _inventoryTransform;
    [SerializeField] private int _maxInventoryCapacity;

    private void Start()
    {
        _items = new List<GameObject>();
        _packMover = GetComponent<ResourcePackMover>();

        _packMover.OnMovedPack += ResourceMoved;
        _packMover.Setup(_inventoryTransform, new Vector3(0, 0.2f, 0), 0.2f);
    }

    private void ResourceMoved(GameObject pack)
    {
        _items.Add(pack);
        pack.transform.parent = _inventoryTransform;
        
    }

    /// API
    public void PutItem(GameObject item)
    {
        if (CanPutItem(item) == false) { throw new InvalidOperationException("Inventory is full"); }
        _packMover.MovePack(item);
    }

    public bool CanPutItem(GameObject item)
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

    public List<ResourcePackData> GetResources()
    {
        List<ResourcePackData> resources = new List<ResourcePackData>();

        foreach (var item in _items)
        {
            ResourcePackData dataComponent;

            if (item.TryGetComponent(out dataComponent))
            {
                resources.Add(dataComponent);
            }
        }

        return resources;
    }

    public void ClearInventory()
    {
        foreach (var item in _items)
        {
            Destroy(item);
        }

        _items = new List<GameObject>();
        _packMover.ClearOffset();
    }

}
