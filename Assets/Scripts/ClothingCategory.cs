using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable, CreateAssetMenu(fileName = "Clothing", menuName = "ScriptableObjects/ClothingData", order = 1)]
public class ClothingCategory : ScriptableObject
{
    public List<ClothingObject> Clothes;
}

[Serializable]
public class ClothingObject
{
    public string Name;
    public Sprite Sprite;
    public Vector2 offset = Vector2.down;

    public bool Colourizable; //Determines if the *player* can change the colour.
    public Color DefaultColour = Color.white;

    public static ClothingObject None = new ClothingObject() {Name = "None", Sprite = null, offset = Vector2.zero, DefaultColour = Color.white};
}
