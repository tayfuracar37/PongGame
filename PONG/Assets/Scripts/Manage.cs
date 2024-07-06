using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Chat;

public class Manage : MonoBehaviourPunCallbacks
{

    




    public static Manage Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }





    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Servere girildi");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Lobiye Girildi");
        PhotonNetwork.JoinOrCreateRoom("Oda", new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Odaya girildi");

       GameObject Oyuncu = PhotonNetwork.Instantiate("Player", new Vector2(7,0), Quaternion.identity, 0, null);
      



     
    }

    public override void OnLeftLobby()
    {
        Debug.Log("Lobiden Çýkýldý");
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Odadan Çýkýldý");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Herhangi bir odaya girilmedi");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Odaya girilmedi");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Oda kurulmadý");
    }
}
