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

    private SpriteAnimator Animator;

    CustomizableCharacter Owner;
    
    public int CurrentSelectedIndex = 0;

    public int SlotLayerOffset = 1;

    private Vector2 BasePosition;

    public ClothingObject CurrentlySelectedClothing
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
        Owner = GetComponentInParent<CustomizableCharacter>();
        Animator = GetComponent<SpriteAnimator>();
        BasePosition = transform.localPosition;
        Init();
    }

    public void Init()
    {
        Animator.Animations = CurrentlySelectedClothing.Animations;
        SpriteRenderer.color = CurrentlySelectedClothing.DefaultColour;
        SpriteRenderer.sortingOrder =
            Owner.SpriteRenderer.sortingOrder + SlotLayerOffset + CurrentlySelectedClothing.LayerOffset;
        
        transform.localPosition = BasePosition + CurrentlySelectedClothing.offset;
        
    }

    public void NextClothes()
    {
        CurrentSelectedIndex = CurrentSelectedIndex >= Category.Clothes.Count - 1 ? 0 : CurrentSelectedIndex + 1;
        Init();
        Animator.Owner.Refresh();
        Animator.Refresh();
    }
    
    
}
