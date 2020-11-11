using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{
    string Name { get; }
    Sprite Image { get; }
    GameObject gameObject { get; set; }
    void OnPickUp();
    void OnDrop();
}

public class InventoryEventArgs : EventArgs
{
    public IInventoryItem Item;
    public float rotZ;
    public bool smallUI;

    public InventoryEventArgs(IInventoryItem item, float rotation, bool isSmall)
    {
        Item = item;
        rotZ = rotation;
        smallUI = isSmall;
    }
}
