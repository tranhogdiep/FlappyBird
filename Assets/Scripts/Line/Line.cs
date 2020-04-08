﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    BoxCollider2D colli;
    RectTransform rectTrans;
    Vector3 temp_pos;
    // Start is called before the first frame update
    private void Awake()
    {
        colli = this.gameObject.GetComponent<BoxCollider2D>();
        rectTrans = this.gameObject.GetComponent<RectTransform>();
    }
    public void SetupLine(float _width = 150, float _height = 500, float _pos_x = 1000)
    {
        Debug.Log("SetupLine: high:"+ _height+" pos:"+ _pos_x);
        temp_pos = gameObject.transform.position;
        temp_pos.x = _pos_x;
        //object width, height
        gameObject.transform.position = temp_pos;
        rectTrans.sizeDelta = new Vector2(_width, _height);

        //collider width, height
        colli.size = new Vector2(_width, _height);
        colli.offset = new Vector2(0, _height / 2);//pivot at bottom
    }
    // Update is called once per frame
    void Update()
    {
        MoveMent();
    }

    private void MoveMent()
    {
        //float x = gameObject.transform.localPosition.x - ;
        //Debug.Log("Move:"+x);
        temp_pos = gameObject.transform.position;
        temp_pos.x -= GameManager.Instance.GetSpeed() * Time.deltaTime;
        gameObject.transform.position = temp_pos;
    }
}