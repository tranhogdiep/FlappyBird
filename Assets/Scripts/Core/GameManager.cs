using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    float speed = 3f;
    int point = 0;
    int level = 1;
    public enum GAMESTATE { WAITING, PLAYING, END};
    private GAMESTATE current_state = GAMESTATE.WAITING;
    public GAMESTATE Current_state
    {
        get { return current_state; }
        set {
            current_state = value;
            switch (current_state)
            {
                case GameManager.GAMESTATE.PLAYING:
                    UIManager.Instance.PlayGame();
                    break;
                case GameManager.GAMESTATE.WAITING:
                    MainPlayer.Instance.LockMove(true);
                    LinesCreator.Instance.DestroyAllLine();
                    UIManager.Instance.Home();
                    break;
                case GameManager.GAMESTATE.END:
                    this.EndGame();
                    UIManager.Instance.EndGame();
                    break;
                default:
                    Debug.LogError("State node found");
                    break;
            }
        }
    }
    public float GetSpeed() { return speed; }
    public float GetLevel() { return level; }
    // Start is called before the first frame update
    void Start()
    {
        Current_state = GAMESTATE.WAITING;
    }

    internal void AddPoint()
    {
        point += 1;
        UIManager.Instance.SetPoint(point);
    }
    internal int GetPoint(){ return point; }
    void EndGame()
    {
        if(point >= StorageManager.GetBestPoint())
            StorageManager.SetBestPoint(point);

    }
}
