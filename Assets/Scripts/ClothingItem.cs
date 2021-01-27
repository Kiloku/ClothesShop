using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClothingItem
{
    public string NiceName;
    public string BaseName;
    public ClothingCategory Category;
    public string Description;
    public Sprite Icon;
    public Vector2 IconOffset;
    public float IconScale = 1f;
    public int Price;

    public ClothingObject BaseObject => Category.Clothes.Find(x => x.Name == BaseName);
    public Color IconColour => BaseObject.DefaultColour;
}
