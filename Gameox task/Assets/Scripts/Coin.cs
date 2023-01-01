using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviourPunCallbacks
{
    Transform player;
    [SerializeField] int Speed;
  
   
   
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
       
        StartCoroutine(DisplaySprite());
       
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine) return;

        Vector2 x = (player.position - transform.position).normalized;
        transform.Translate(Speed*Time.deltaTime * x);
    }

    IEnumerator DisplaySprite()
    {
        yield return new WaitForSeconds(2f);
        
        gameObject.SetActive(false);
        
    }

}