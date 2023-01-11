using TMPro;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI totalScoreText;
    [SerializeField] GameObject PlusScoreobject;
   // [SerializeField] Instantiate coins;


    private void Awake()
    {
        //coins = Instantiate(coins);
        //Score.SetPlusScoreObject(PlusScoreobject);
        //Score.SetCoins(coins);
    }
    private void FixedUpdate()
    {
        PlayerUpdateTotalScore();
    }
    public  void PlayerUpdateTotalScore()
    {
      //  totalScoreText.text = Score.GetTotalScore().ToString();
    }


}
