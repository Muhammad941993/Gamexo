using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Lancher : MonoBehaviourPunCallbacks
{
    int playerNumber =0;
    [SerializeField] Transform[] playerPosition = new Transform[3] ;
    [SerializeField] GameObject Fishbool;
    [SerializeField] GameObject Player;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Connect_CallBack();
            
        }
    }
    public void Connect_CallBack()
    {
      
      
    }

    public override void OnConnectedToMaster()
    {
        print("Conect To Master .........");
        //PhotonNetwork.JoinLobby(TypedLobby.Default);
        PhotonNetwork.JoinRandomOrCreateRoom();
       
    }

    public override void OnCreatedRoom()
    {
        PhotonNetwork.CurrentRoom.MaxPlayers = 3;
       
    }
    public override void OnJoinedLobby()
    {
        print("Join To Lobby ....");
    }
    public override void OnJoinedRoom()
    {
        print("Join To Room");
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(Fishbool.name, Fishbool.transform.position, Quaternion.identity);
            PhotonNetwork.Instantiate(Player.name, playerPosition[0].position, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate(Player.name, playerPosition[1].position, Quaternion.identity);
        }



        //if (PhotonNetwork.IsMasterClient)
           
        //playerNumber++;

    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Dissconnect");
    }
}
