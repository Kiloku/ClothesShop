using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based on: https://www.gamasutra.com/blogs/JoeStrout/20150807/250646/2D_Animation_Methods_in_Unity.php
public class SpriteAnimator : MonoBehaviour
{
    public List<SpriteAnimation> Animations;

    public int CurrentFrame;
    
    public bool done => CurrentFrame >= currentAnimation.frames.Length;

    public bool playing
    {
        get;
        private set;
    }

    public SpriteAnimator ParentAnimator;

    private SpriteRenderer spriteRenderer;
    private SpriteAnimation currentAnimation;
    private float secsPerFrame;
    private float nextFrameTime;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetAnimation(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing || Time.time < nextFrameTime) return;
        
        CurrentFrame++;
        if (CurrentFrame >= currentAnimation.frames.Length)
        {
            if (!currentAnimation.loop)
            {
                playing = false;
                return;
            }
            CurrentFrame = 0;
        }
        SetFrame(CurrentFrame);
        // spriteRenderer.sprite = currentAnimation.frames[CurrentFrame];
        nextFrameTime += secsPerFrame;

    }


    public void Play()
    {
        
        secsPerFrame = 1f / currentAnimation.framesPerSecond;
        playing = true;
        nextFrameTime = Time.time;
    }

    public void SetAnimation(string name)
    {
        if (currentAnimation.name == name) return;
        int index = Animations.FindIndex(anim => anim.name == name);

        if (index < 0)
        {
            Debug.LogError($"Animation {name} not found in {gameObject.name}");
        }
        else
        {
            SetAnimation(index);
        }

    }
    
    private SpriteAnimation SetAnimation(int index)
    {
        SpriteAnimation animation = Animations[index];
        currentAnimation = animation;
        
        if (currentAnimation.invisible)
        {
            spriteRenderer.color *= new Color(1, 1, 1, 0);
        }
        else
        {
            spriteRenderer.color += new Color(0, 0, 0,1);
        }

        SetFrame(0);

        return animation;
    }

    public void SetFrame(int frame)
    {
        if (frame >= currentAnimation.frames.Length) frame = 0;
        CurrentFrame = frame;
        spriteRenderer.sprite = currentAnimation.frames[CurrentFrame];
    }

    public void Stop()
    {
        playing = false;
    }

    public void StopAt(int frame)
    {
        
        SetFrame(frame);
        Stop();
    }

    public void Resume()
    {
        playing = true;
        nextFrameTime = Time.time + secsPerFrame;
    }
}
