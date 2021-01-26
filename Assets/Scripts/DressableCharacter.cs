using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressableCharacter : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    
    public SpritePiece Hat;
    public SpritePiece Shirt;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Hat.NextClothes();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shirt.NextClothes();
        }
    }
}
