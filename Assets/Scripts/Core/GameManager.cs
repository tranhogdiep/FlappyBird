﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    float speed = 3f;
    float line_space = 5f;
    public float GetSpeed() { return speed; }
    public float GetLineSpace() { return line_space; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}