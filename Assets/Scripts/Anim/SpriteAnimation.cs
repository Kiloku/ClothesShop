using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based on: https://www.gamasutra.com/blogs/JoeStrout/20150807/250646/2D_Animation_Methods_in_Unity.php
[Serializable]
public class SpriteAnimation
{
    public string name;
    public Sprite[] frames;
    public float framesPerSecond = 5;
    public bool loop = true;
    public bool invisible;
    
    
    public float duration
    {
        get => frames.Length * framesPerSecond;
        set => framesPerSecond = value / frames.Length;
    }
    
    
    
    
}
