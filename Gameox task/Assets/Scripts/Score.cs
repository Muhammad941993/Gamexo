using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class Score
{
    static int TotalScote = 0;
    static GameObject PlusScoreObject;
    static Instantiate Coins;
    public static void UpdateTotalScore(int Score)
    {
        TotalScote += Score;
      
    }
    public static void SetCoins(Instantiate coin) { Coins = coin; }
    public static Instantiate GetCoins() { return Coins; }
    public static void SetPlusScoreObject (GameObject gameObject) { PlusScoreObject = gameObject; }
    public static GameObject GetPlusScoreObject() { return PlusScoreObject; }
    public static int GetTotalScore() {return TotalScote; }
   
}
