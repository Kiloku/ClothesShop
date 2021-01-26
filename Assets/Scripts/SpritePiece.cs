using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpritePiece : MonoBehaviour 
{
    //TODO: Auto-set orderInLayer
    [SerializeField]
    public ClothingCategory Category;

    private SpriteRenderer SpriteRenderer;
    
    DressableCharacter Owner;
    
    public int CurrentSelectedIndex = 0;

    public int SlotLayerOffset = 1;

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
        Owner = GetComponentInParent<DressableCharacter>();
        BasePosition = transform.localPosition;
        SetSprite();
    }

    public void SetSprite()
    {
        SpriteRenderer.sprite = CurrentlySelected.Sprite;
        SpriteRenderer.color = CurrentlySelected.DefaultColour;
        SpriteRenderer.sortingOrder =
            Owner.SpriteRenderer.sortingOrder + SlotLayerOffset + CurrentlySelected.LayerOffset;
        
        transform.localPosition = BasePosition + CurrentlySelected.offset;
    }

    public void NextClothes()
    {
        CurrentSelectedIndex = CurrentSelectedIndex >= Category.Clothes.Count - 1 ? -1 : CurrentSelectedIndex + 1;
        SetSprite();
    }
    
    
}
