using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUISlot : MonoBehaviour
{
    public Image IconImage;

    public ClothingItem Item;

    public InventoryUI Inventory;

    public Button myButton;

    private EventTrigger EventTrigger;

    private void Start()
    {
        myButton.onClick.AddListener(SelectCurrentItem);
        EventTrigger = GetComponent<EventTrigger>();
        
        EventTrigger.triggers.Find(t => t.eventID == EventTriggerType.PointerEnter).callback.AddListener(
            (eventData => { Hover();}));
        EventTrigger.triggers.Find(t => t.eventID == EventTriggerType.PointerExit).callback.AddListener(
            (eventData => { UnHover();}));
    }

    public void SetItem(ClothingItem item)
    {
        Debug.Log("SetItem: " + gameObject.name);
        Item = item;
        if (Item == null)
        {
            IconImage.gameObject.SetActive(false);
            myButton.interactable = false;
        }
        else
        {
            IconImage.gameObject.SetActive(true);
            myButton.interactable = true;
            IconImage.sprite = item.Icon;
            IconImage.color = item.IconColour;
            IconImage.transform.localScale = Vector2.one * item.IconScale;
            IconImage.transform.localPosition = Vector2.zero + item.IconOffset;
        }
    }

    public void SelectCurrentItem()
    {
        Inventory.playerInventory.SetClothes(Item);
    }

    public void Hover()
    {
        if (Item == null) return;
        Inventory.Description.text = Item.Description;
    }

    public void UnHover()
    {
        if (Item == null) return;
        Inventory.Description.text = "";
    }
}
