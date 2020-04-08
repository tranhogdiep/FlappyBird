using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPopup : Popup
{
    public Text point;
    public Text bestPoint;
    public override void ShowPopup(string title)
    {
        base.ShowPopup(title);
        point.text = GameManager.Instance.GetPoint().ToString();
        bestPoint.text = StorageManager.GetBestPoint().ToString();
    }
}
