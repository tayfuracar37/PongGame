using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Chat;

public class Manage : MonoBehaviourPunCallbacks
{
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
      //PhotonNetwork.JoinRandomRoom();
    }


    public override void OnJoinedRoom()
    {
        Debug.Log("Odaya girildi");

        GameObject nesne = PhotonNetwork.Instantiate("Square", Vector3.zero, Quaternion.identity, 0, null);
    }
    
    public override void OnLeftLobby()
    {

        Debug.Log("Lobiden ��k�ld�");
    }


    public override void OnLeftRoom()
    {
        Debug.Log("Odadan ��k�ld�");
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
        Debug.Log("Oda kurulmda�");
    }


}
