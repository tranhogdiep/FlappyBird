using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Text title;
    public virtual void ShowPopup(string title)
    {
            this.title.text = title;
    }
    public virtual void HidePopup()
    {
        this.gameObject.SetActive(false);
    }
}
