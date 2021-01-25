using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressableCharacter : MonoBehaviour
{
    public Sprite characterBase;

    public ClothingSlot hat;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            hat.CurrentSelectedIndex = 1;
            hat.SetSprite();
        }
    }
}
