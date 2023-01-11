using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score
{
    [SerializeField] int PlayerTotalScore = 0;
    static GameObject PlusScoreObject;
    static Instantiate Coins;
    public void UpdateTotalScore(int Score)
    {
        PlayerTotalScore += Score;
      
    }
    public  void SetCoins(Instantiate coin) { Coins = coin; }
    public  Instantiate GetCoins() { return Coins; }
    public  void SetPlusScoreObject (GameObject gameObject) { PlusScoreObject = gameObject; }
    public  GameObject GetPlusScoreObject() { return PlusScoreObject; }
    public  int GetTotalScore() {return PlayerTotalScore; }
   
}
