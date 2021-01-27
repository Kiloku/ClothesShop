using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPrompt : MonoBehaviour
{
    public GameObject Target;
    public Vector2 offset;
    private Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null && mainCamera != null)
        {
            transform.position = (Vector2) mainCamera.WorldToScreenPoint(Target.transform.position ) + offset;
        }
    }
}
