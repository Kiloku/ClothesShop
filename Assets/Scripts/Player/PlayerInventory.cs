using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int money = 1000;
    public List<ClothingItem> Items;
    public TextMeshProUGUI MoneyCounter;
    private CustomizableCharacter myCharacter;


    private void Start()
    {
        myCharacter = GetComponent<CustomizableCharacter>();
    }

    public void SetClothes(ClothingItem item)
    {
        myCharacter.SetClothes(item.Category, item.BaseName);
    }

    private void Update()
    {
        MoneyCounter.text = money + "g";
    }
}
