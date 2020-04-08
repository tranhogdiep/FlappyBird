using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    float speed = 3f;
    float line_space = 5f;
    int point = 0;
    public enum GAMESTATE { WAITING, PLAYING, END};
    private GAMESTATE current_state = GAMESTATE.WAITING;
    public GAMESTATE Current_state
    {
        get { return current_state; }
        set {
            current_state = value;
            UIManager.Instance.ChangeState(current_state);
        }
    }
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

    internal void AddPoint()
    {
        point += 1;
        UIManager.Instance.SetPoint(point);
    }
}
