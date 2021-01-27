using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;
using UnityEngine;

public class CustomizableCharacter : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    
    public SpritePiece Hat;
    public SpritePiece Pants;
    public SpritePiece Shirt;
    
    
    public PlayerInventory Inventory;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
    }

    public SpritePiece GetPieceFromCategory(ClothingCategory category)
    {
        if (category == Hat.Category) return Hat;
        if (category == Pants.Category) return Pants;
        if (category == Shirt.Category) return Shirt;
        return null;
    }

    public void SetClothes(ClothingCategory category, string name)
    {
        if (category == Hat.Category)
        {
            Hat.SetClothes(name);
        }
        else if (category == Shirt.Category)
        {
            Shirt.SetClothes(name);
        }
        else if (category == Pants.Category)
        {
            Pants.SetClothes(name);
        }
    }
}
