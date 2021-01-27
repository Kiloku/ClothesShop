using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CustomizableCharacter Character;

    public CompositeAnimator animator;

    public GameObject ShopUI;

    public GameObject SpacePrompt;
    
    private void Start()
    {
        Character = GetComponent<CustomizableCharacter>();
        animator.CurrentAnimationName = "Down";
    }

    private bool NearVendor;

    // Update is called once per frame    
    void Update()
    {
        AnimatorUpdate();
        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0)* Time.deltaTime, Space.Self) ;

        
        if (NearVendor && Input.GetKeyDown(KeyCode.Space))
        {
            ShopUI.SetActive(true);
            SpacePrompt.SetActive(false);
        }
    }

    void AnimatorUpdate()
    {
        if (Input.GetAxisRaw("Vertical") > 0.1f)
        {
            animator.SetAnimation("Up");
        }
        if (Input.GetAxisRaw("Vertical") < -0.1f)
        { 
            animator.SetAnimation("Down");
        }
        if (Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            animator.SetAnimation("Left");
        }
        if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            animator.SetAnimation("Right");
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            if(animator.playing) animator.StopAt(0);
        }
        else
        {
            if (!animator.playing) animator.Play();
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "vendor")
        {
            SpacePrompt.SetActive(true);
            NearVendor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "vendor")
        {
            SpacePrompt.SetActive(false);
            NearVendor = false;
        }
    }
}
