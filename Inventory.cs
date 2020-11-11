using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    const int slots = 4;

    List<IInventoryItem> items = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public event EventHandler<InventoryEventArgs> ItemRemoved;

    public void AddItem(IInventoryItem item, float rotZ, bool isSmall)
    {
        items.Add(item);
        item.OnPickUp();
        if (ItemAdded != null)
        {
            ItemAdded(this, new InventoryEventArgs(item, rotZ, isSmall));
        }
    }

    public void RemoveItem(IInventoryItem item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            item.OnDrop();
            if (ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item, 0, false));
            }
        }
    }
}
