using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeAnimator : MonoBehaviour
{
    public List<SpriteAnimator> Animators;

    public string CurrentAnimationName;
    public int CurrentFrame;

    public int framesPerSecond;
    private float secsPerFrame;
    private float nextFrameTime;

    private int maxLength;
    
    public bool playing
    {
        get;
        private set;
    }

    void CalculateMaxLength()
    {
        int length = 0;
        
        foreach (var animator in Animators)
        {
            if (animator.currentAnimation == null) continue;
            if (animator.currentAnimation.frames.Length > length) length = animator.currentAnimation.frames.Length;
        }

        maxLength = length;
    }

    private void Start()
    {
        foreach (var animator in Animators)
        {
            animator.Owner = this;
            animator.Init();
            animator.SetAnimation(CurrentAnimationName);
        }
        CalculateMaxLength();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing || Time.time < nextFrameTime) return;
        
        CurrentFrame++;
        if (CurrentFrame >= maxLength)
        {
            CurrentFrame = 0;
        }
        SetFrame(CurrentFrame);
        
        nextFrameTime += secsPerFrame;
    }


    public void Refresh()
    {
        SetAnimation(CurrentAnimationName, true);
        SetFrame(CurrentFrame);
    }

    public void SetAnimation(string name, bool force = false)
    {
        if (!force && CurrentAnimationName == name) return;
        CurrentAnimationName = name;
        foreach (var animator in Animators)
        {
            animator.SetAnimation(name, force);
        }
    }

    void SetFrame(int frame)
    {
        if (frame >= maxLength) frame = 0;
        CurrentFrame = frame;
        foreach (var animator in Animators)
        {
            if (animator.currentAnimation == null) continue;
            if (CurrentFrame < animator.currentAnimation.frames.Length)
            {
                animator.SetFrame(CurrentFrame);
            }
            else
            {
                animator.SetFrame(animator.currentAnimation.frames.Length-1);
            }
        }
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
    
    public void Play()
    {
        secsPerFrame = 1f / framesPerSecond;
        playing = true;
        nextFrameTime = Time.time;
    }

    public void RegisterAnimator(SpriteAnimator animator)
    {
        Animators.Add(animator);
        animator.Owner = this;
        CalculateMaxLength();
        animator.SetAnimation(CurrentAnimationName);
        
        if (CurrentFrame < animator.currentAnimation.frames.Length)
        {
            animator.SetFrame(CurrentFrame);
        }
        else
        {
            animator.SetFrame(animator.currentAnimation.frames.Length-1);
        }
    }

}
