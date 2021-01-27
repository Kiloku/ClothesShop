using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Image IconImage;

    public ClothingItem Item;

    public Shop Shop;

    private Button _myButton;

    private Button myButton
    {
        get
        {
            if (_myButton == null)
            {
                _myButton = GetComponent<Button>();
            }
            return _myButton;
        }
    }

    private EventTrigger EventTrigger;

    private void Start()
    {
        myButton.onClick.AddListener(SellCurrentItem);
        EventTrigger = GetComponent<EventTrigger>();
        
        EventTrigger.triggers.Find(t => t.eventID == EventTriggerType.PointerEnter).callback.AddListener(
            (eventData => { Hover();}));
        EventTrigger.triggers.Find(t => t.eventID == EventTriggerType.PointerExit).callback.AddListener(
            (eventData => { UnHover();}));
    }

    public void SetItem(ClothingItem item)
    {
        
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

    public void SellCurrentItem()
    {

        if (Shop.playerInventory.money >= Item.Price)
        {
            Shop.playerInventory.Items.Add(Item);
            Shop.playerInventory.money -= Item.Price;
            Shop.Items.Remove(Item);
            SetItem(null);
        }
    }

    public void Hover()
    {
        if (Item == null) return;
        Shop.Description.text = Item.Description + " (" + Item.Price + "g)";
    }

    public void UnHover()
    {
        if (Item == null) return;
        Shop.Description.text = "";
    }
}
