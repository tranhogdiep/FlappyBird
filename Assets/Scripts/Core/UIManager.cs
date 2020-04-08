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
    public GameObject chooseBirdPopup;

    Vector3 hidePos = new Vector3(0, -10, 0);
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
    public void OnClickBackToHome()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.SOUNDS.TAB_BOTTON);
        GameManager.Instance.Current_state = GameManager.GAMESTATE.WAITING;
    }
    public void OnClickChooseBird()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.SOUNDS.TAB_BOTTON);
        ShowPopup(chooseBirdPopup, GameString.CHOOSE_BIRD);
    }
    public void OnClickPlayerGame()
    {
        MainPlayer.Instance.WaitForStartGame();
    }

    public void Home()
    {
        SetPoint(0);
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
        ShowPopup(gameOverPopup, GameString.GAME_OVER);
    }
    void HidePanel(GameObject panel)
    {
        //panel.transform.Translate(hidePos);
        //waitForHide.Add(panel);
        panel.SetActive(false);
    }
    void ShowPanel(GameObject panel)
    {
        //panel.transform.Translate(Vector3.zero);
        panel.SetActive(true);
    }
    void ShowPopup(GameObject popup, string tile)
    {
        popup.SetActive(true);
        popup.GetComponent<Popup>().ShowPopup(tile);
    }
    private void Update()
    {
        //if(waitForHide.Count>0)
        //{
        //    foreach(GameObject obj in waitForHide)
        //    {
        //        obj.transform.localScale = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y-0.1f, obj.transform.localScale.z);
        //        if(obj.transform.localScale.y<=0)
        //        {
        //            obj.transform.localScale = new Vector3(obj.transform.localScale.x, 0, obj.transform.localScale.z);
        //            waitForHide.Remove(obj);
        //        }
        //    }
        //}
    }
}
