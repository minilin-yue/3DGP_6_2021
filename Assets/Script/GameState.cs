using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    static public bool isPlaying = false;
    public static void GameStart()
    {
        isPlaying = true;
    }
    public static void GamePause()
    {
        isPlaying = false;
    }
}
