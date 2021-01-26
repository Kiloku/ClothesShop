using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    private Facing facing;
    public enum Facing { Up, Down, Left, Right }

    public Sprite UpIdle;
    public Sprite DownIdle;

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetFacing(Facing facing)
    {
        this.facing = facing;
        switch (this.facing)
        {
            case Facing.Up:
                SpriteRenderer.sprite = UpIdle;
                break;
            case Facing.Down:
                SpriteRenderer.sprite = DownIdle;
                break;
            default: break;
                
            
        }
    }
    
}
