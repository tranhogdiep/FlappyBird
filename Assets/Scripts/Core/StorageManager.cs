using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class StorageManager
{
    public enum BIRD  {RED, BLUE, YELLOW};
    public const string
        PLAYER_NAME = "playerName",
        BEST_POINT = "bestPoint",
        CHARACTER = "character";
    public static int GetBestPoint()
    {
        return PlayerPrefs.GetInt(BEST_POINT);
    }
    public static void SetBestPoint(string point)
    {
        PlayerPrefs.SetInt(BEST_POINT, Int32.Parse(point));
    }
    public static void SetBestPoint(int point)
    {
        PlayerPrefs.SetInt(BEST_POINT, point);
    }

    public static BIRD GetBird()
    {
        int bird = PlayerPrefs.GetInt(CHARACTER);
        if(bird == 0)
        {
            return BIRD.RED;
        }
        else if (bird == 1)
        {
            return BIRD.BLUE;
        }
        else if (bird == 2)
        {
            return BIRD.YELLOW;
        }
        Debug.LogError("Bird not found");
        return BIRD.RED;
    }
    public static void SetBird(BIRD value)
    {
        PlayerPrefs.SetInt(CHARACTER, (int)value);
    }
}
