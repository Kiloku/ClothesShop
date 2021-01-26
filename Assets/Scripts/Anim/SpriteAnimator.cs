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

    private SpriteRenderer spriteRenderer;

    public SpriteAnimation currentAnimation
    {
        get;
        private set;
    }
    private float secsPerFrame;
    private float nextFrameTime;

    public CompositeAnimator Owner;
    public bool partOfComposite => Owner != null;
    
    public void Init()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetAnimation(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing || Time.time < nextFrameTime || partOfComposite) return;
        
        CurrentFrame++;
        if (CurrentFrame >= currentAnimation.frames.Length)
        {
            CurrentFrame = 0;
        }
        SetFrame(CurrentFrame);
        
        nextFrameTime += secsPerFrame;
    }


    public void Play()
    {
        
        secsPerFrame = 1f / currentAnimation.framesPerSecond;
        playing = true;
        nextFrameTime = Time.time;
    }

    public void SetAnimation(string name, bool force = false)
    {
        if (!force)
        {
            if ((Animations == null || Animations.Count <= 0) ||
                (currentAnimation != null && currentAnimation.name == name)) return;
        }

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
        if (Animations == null || Animations.Count <= 0) return null;
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
        if (currentAnimation == null) return;
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

    public void Refresh()
    {
        SetAnimation(currentAnimation.name);
        SetFrame(CurrentFrame);
        spriteRenderer.sprite = currentAnimation.frames[CurrentFrame];
    }
}
