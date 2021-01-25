using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressableCharacter : MonoBehaviour
{
    public Sprite characterBase;

    public ClothingSlot Hat;
    public ClothingSlot Shirt;
    
    void Start()
    {
        
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
