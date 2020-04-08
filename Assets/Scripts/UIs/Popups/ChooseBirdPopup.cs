using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBirdPopup : Popup
{
    public Toggle red;
    public Toggle blue;
    public Toggle yellow;
    StorageManager.BIRD character;
    public override void ShowPopup(string title)
    {
        base.ShowPopup(title);
        if(StorageManager.GetBird()== StorageManager.BIRD.RED)
        {
            red.isOn = true;
        }
        else if (StorageManager.GetBird() == StorageManager.BIRD.BLUE)
        {
            blue.isOn = true;
        }
        else if (StorageManager.GetBird() == StorageManager.BIRD.YELLOW)
        {
            yellow.isOn = true;
        }
    }
    public void OnClickRedBird()
    {
        StorageManager.SetBird(StorageManager.BIRD.RED);
        character = StorageManager.BIRD.RED;
    }
    public void OnClickBlueBird()
    {
        StorageManager.SetBird(StorageManager.BIRD.BLUE);
        character = StorageManager.BIRD.BLUE;
    }
    public void OnClickYellowBird()
    {
        StorageManager.SetBird(StorageManager.BIRD.YELLOW);
        character = StorageManager.BIRD.YELLOW;
    }
    public override void HidePopup()
    {
        base.HidePopup();
        MainPlayer.Instance.SetCharacter(character);
    }
}
