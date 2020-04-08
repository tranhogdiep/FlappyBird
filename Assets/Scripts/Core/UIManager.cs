using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField]
    Text txtPoint;

    public GameObject homeUI;
    public GameObject playingUI;
    public GameObject gameOverPopup;

    List<GameObject> waitForHide;
    private void Start()
    {
        gameOverPopup.SetActive(false);
        waitForHide = new List<GameObject>();
    }
    public void SetPoint(int point)
    {
        txtPoint.text = point.ToString();
    }
    public void ChangeState(GameManager.GAMESTATE state)
    {
        switch(state)
        {
            case GameManager.GAMESTATE.PLAYING:
                PlayGame();
                break;
            case GameManager.GAMESTATE.WAITING:
                Home();
                break;
            case GameManager.GAMESTATE.END:
                EndGame();
                break;
            default:
                Debug.LogError("State node found");
                break;
        }
    }

    private void Home()
    {
        HidePanel(playingUI);
        HidePanel(gameOverPopup);
        ShowPanel(homeUI);
    }

    public void PlayGame()
    {
        ShowPanel(playingUI);
        HidePanel(homeUI);
        HidePanel(gameOverPopup);
    }
    public void EndGame()
    {
        ShowPanel(gameOverPopup);
    }
    void HidePanel(GameObject panel)
    {
        waitForHide.Add(panel);
    }
    void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    private void Update()
    {
        if(waitForHide.Count>0)
        {
            foreach(GameObject obj in waitForHide)
            {
                obj.transform.localScale = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y-0.1f, obj.transform.localScale.z);
                if(obj.transform.localScale.y<=0)
                {
                    obj.transform.localScale = new Vector3(obj.transform.localScale.x, 0, obj.transform.localScale.z);
                    waitForHide.Remove(obj);
                }
            }
        }
    }
}
