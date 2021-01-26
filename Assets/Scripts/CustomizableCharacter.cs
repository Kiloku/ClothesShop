using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizableCharacter : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    
    public SpritePiece Hat;
    public SpritePiece Pants;
    public SpritePiece Shirt;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Pants.NextClothes();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shirt.NextClothes();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Hat.NextClothes();
        }
    }
}
