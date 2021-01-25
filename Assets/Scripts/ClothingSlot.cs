using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClothingSlot : MonoBehaviour
{
    //TODO: Auto-set orderInLayer
    [SerializeField]
    public ClothingCategory Category;

    private SpriteRenderer SpriteRenderer;
    
    public int CurrentSelectedIndex = 0;

    private Vector2 BasePosition;

    public ClothingObject CurrentlySelected
    {
        get
        {
            if (CurrentSelectedIndex < 0) return ClothingObject.None;
            return Category.Clothes[CurrentSelectedIndex];
        }
    }

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        BasePosition = transform.localPosition;
        SetSprite();
    }

    public void SetSprite()
    {
        SpriteRenderer.sprite = CurrentlySelected.Sprite;
        transform.localPosition = BasePosition + CurrentlySelected.offset;
        SpriteRenderer.color = CurrentlySelected.DefaultColour;
    }

    public void NextClothes()
    {
        CurrentSelectedIndex = CurrentSelectedIndex >= Category.Clothes.Count - 1 ? -1 : CurrentSelectedIndex + 1;
        SetSprite();
    }
    
    
}
