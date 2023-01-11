using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Lancher : MonoBehaviourPunCallbacks
{
    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;
    [SerializeField] Transform[] playerPosition = new Transform[3] ;
    [SerializeField] GameObject Fishbool;
    [SerializeField] GameObject Player;
    string gameVersion = "1";


    private void Awake()
    {
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel()
        // on the master client and all clients in the same room sync their level automatically

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        Connect();
    }
  

    public void Connect()
    {
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected)
        {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }
  

    public override void OnConnectedToMaster()
    {
        print("Clint Conect To Master .........");
        // #Critical: The first we try to do is to join a potential existing room. If there is, good,
        // else, we'll be called back with OnJoinRandomFailed()
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        print("On join faild create room ....");

        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnCreatedRoom()
    {
        print("Room created ....");
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


    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Server Dissconnect");
    }
}
