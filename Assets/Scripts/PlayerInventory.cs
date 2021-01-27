using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int money = 1000;
    public List<ClothingItem> Items;
    private CustomizableCharacter myCharacter;

    private void Start()
    {
        myCharacter = GetComponent<CustomizableCharacter>();
    }

    public void SetClothes(ClothingItem item)
    {
        myCharacter.SetClothes(item.Category, item.BaseName);
    }
}
