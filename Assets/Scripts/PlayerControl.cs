using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private DressableCharacter Character;
    public SpriteAnimator MainAnimator;
    public SpriteAnimator EyesAnimator;
    private void Start()
    {
        Character = GetComponent<DressableCharacter>();
    }

    // Update is called once per frame    
    void Update()
    {
        AnimatorUpdate();
        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0)* Time.deltaTime, Space.Self) ;
    }

    void AnimatorUpdate()
    {
        if (Input.GetAxisRaw("Vertical") > 0.1f)
        {
            MainAnimator.SetAnimation("Up");
            EyesAnimator.SetAnimation("Up");
        }
        if (Input.GetAxisRaw("Vertical") < -0.1f)
        { 
            MainAnimator.SetAnimation("Down");
            EyesAnimator.SetAnimation("Down");
        }
        if (Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            MainAnimator.SetAnimation("Left");
            EyesAnimator.SetAnimation("Left");
        }
        if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            MainAnimator.SetAnimation("Right");
            EyesAnimator.SetAnimation("Right");
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            if(MainAnimator.playing) MainAnimator.StopAt(0);
            if(EyesAnimator.playing) EyesAnimator.StopAt(0);
        }
        else
        {
            if (!MainAnimator.playing) MainAnimator.Play();
            if (!EyesAnimator.playing) EyesAnimator.Play();
        }
        
    }
}
