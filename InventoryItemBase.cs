using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBase : MonoBehaviour, IInventoryItem
{
    public virtual string Name
    {
        get { return "_base item_"; }
    }

    public Sprite _Image;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    GameObject IInventoryItem.gameObject { get; set; }

    public virtual void OnPickUp()
    {
    }

    public virtual void OnDrop()
    {
        Vector3 dropPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var newObj = Instantiate(gameObject, new Vector3(dropPos.x, dropPos.y, 0), transform.rotation);
        newObj.transform.parent = transform.parent;
    }

}
