using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(ResourcePackMover))]
public class PlayerInventory : MonoBehaviour
{
    private ResourcePackMover _packMover;
    [SerializeField] private List<GameObject> _items;
    [SerializeField] private GameObject _inventoryObject;
    [SerializeField] private int _inventoryCapacity;

    private void Start()
    {
        _items = new List<GameObject>();
        _packMover = GetComponent<ResourcePackMover>();

        _packMover.OnMoved += ResourceMoved;
    }

    private void ResourceMoved(GameObject pack)
    {
        _items.Add(pack);
        pack.transform.parent.parent = _inventoryObject.transform;
        
    }

    public void PutItem(GameObject item)
    {
        if (CanPutItem(item) == false) { throw new InvalidOperationException("Inventory is full"); }
        _packMover.MovePack(item);
    }

    public bool CanPutItem(GameObject item)
    {
        if (_items.Count + 1 > _inventoryCapacity)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
