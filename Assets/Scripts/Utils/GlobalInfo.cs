using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalInfo
{
    public static Dictionary<string, string> gameObjectTag = new Dictionary<string, string>(){
                                                {"MAINPLAYER","mainPlayer"},
                                                {"LINE", "line"}
                                            };
}
public static class GameObjectTag
{
    public const string
        MAIN_PLAYER = "Player",
        LINE = "Line";
}
