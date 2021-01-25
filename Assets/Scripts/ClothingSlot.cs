using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClothingSlot : MonoBehaviour
{
    [SerializeField]
    public ClothingCategory Category;

    private SpriteRenderer SpriteRenderer;
    
    public int CurrentSelectedIndex = 0;

    private Vector2 BasePosition;
    
    public ClothingObject CurrentlySelected => Category.Clothes[CurrentSelectedIndex]; //TODO: Allow for "None";
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
    }
    
    
}
