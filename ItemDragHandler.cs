using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ItemDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public IInventoryItem Item { get; set; }

    ItemDropHandler dropHandler;
    GameObject placeholder;
    GameManager gmg;

    Image sprr;
    Vector3 dropPos;

    void Start()
    {
        dropHandler = GameObject.Find("Inventaire").GetComponent<ItemDropHandler>();
        gmg = FindObjectOfType<GameManager>();
        sprr = transform.gameObject.GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dropPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        placeholder = Instantiate(Item.gameObject, new Vector3(dropPos.x, dropPos.y, 10), Item.gameObject.transform.rotation, gmg.objets.transform);

        Color tmp = placeholder.GetComponent<SpriteRenderer>().color;
        tmp.a = .5f;
        placeholder.GetComponent<SpriteRenderer>().color = tmp;

        FindObjectOfType<AudioManager>().PickItemInv();
        dropHandler.Item = Item;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        dropPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        placeholder.transform.position = new Vector3(dropPos.x, dropPos.y, 10);

        Color tmp = sprr.color;
        tmp.a = 0f;
        sprr.color = tmp;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        Destroy(placeholder);

        Color tmp = sprr.color;
        tmp.a = 1f;
        sprr.color = tmp;
    }
}
