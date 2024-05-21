using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public Vector3 Movement;
    protected Movement _movement;

    protected virtual void Start()
    {
        _movement = GetComponent<Movement>();
    }

    protected virtual void Update()
    {
        if (_movement == null)
            return;
        
    }
}
