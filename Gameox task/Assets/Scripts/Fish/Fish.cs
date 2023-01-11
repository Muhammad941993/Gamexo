using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;


public class Fish : MonoBehaviourPunCallbacks
{
    [SerializeField] int fishScore;
    [SerializeField]  int fishHealth;
    Instantiate Coins;
    GameObject plusScore;
    SpriteRenderer sprite;
    BoxCollider2D boxCollider;
    int health;
    private List<GameObject> fishCoins = new();

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
       // Coins = Score.GetCoins();
      //  plusScore = Score.GetPlusScoreObject();
       
        health = fishHealth;
      
    }

    

    void UpdateScore()
    {
      //  Score.UpdateTotalScore(fishScore);
    }
    public int GetFishScore() { return fishScore; }

    public void DecreaseHelath()
    {

        if (health <= 1)
        {
            StartCoroutine(Death());

        }
        else
        {
            health--;
        }
    }

    IEnumerator Death()
    {
        boxCollider.enabled = false;
        yield return new WaitForSeconds(.3f);
        
        sprite.enabled = false;
        UpdateScore();
        health = fishHealth;
       // plusScore.transform.position = transform.position;
       // plusScore.GetComponent<TextMeshProUGUI>().text = "+" + fishScore.ToString();
       // plusScore.SetActive(true);
        GetCoins();
        yield return new WaitForSeconds(.5f);
        ClearCoins();
        plusScore.SetActive(false);
        sprite.enabled = true;
        boxCollider.enabled = true;
        gameObject.SetActive(false);
    }


    void GetCoins()
    {
        for (int i = 0; i < fishHealth; i++)
        {
            var coin = Coins.GetPrefabFromTheBool();
            if (coin == null) return;
            coin.transform.position = transform.position + new Vector3(i * .5f, 0, 0);
            fishCoins.Add(coin);
            coin.SetActive(true);
        }
    }
    
    void ClearCoins()
    {
        fishCoins.Clear();
    }

}
