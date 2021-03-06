﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<ClothingItem> Items;

    public List<ShopSlot> ItemSlots;

    public ClothingCategory initialCategory;

    public PlayerInventory playerInventory;

    public TextMeshProUGUI Description;

    private ClothingCategory lastCategory;

    public GameObject InventoryButton;
    // Start is called before the first frame update
    void Start()
    {
        SelectCategory(initialCategory);
        foreach (var slot in ItemSlots)
        {
            slot.Shop = this;
        }
        InventoryButton.SetActive(false);
    }

    private void OnEnable()
    {
        SelectCategory(lastCategory);
    }

    private void OnDisable()
    {
        InventoryButton.SetActive(true);
    }

    public void SelectCategory(ClothingCategory category)
    {
        lastCategory = category;
        List<ClothingItem> filtered = Items.FindAll(x => x.Category == category);

        for (int i = 0; i < ItemSlots.Count ; i++)
        {
            if (i >= filtered.Count)
            {
                ItemSlots[i].SetItem(null);
            }
            else
            {
                ItemSlots[i].SetItem(filtered[i]);
            }
        }
    }
}
