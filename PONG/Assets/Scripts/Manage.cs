using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Chat;
using UnityEngine.SceneManagement;
public class Manage : MonoBehaviourPunCallbacks
{

    static Manage manage = null;
    




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
        if (manage == null)
        {
            manage = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }




        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Servere girildi");
        PhotonNetwork.JoinLobby();
    }

  /* public override void OnJoinedLobby()
    {
        Debug.Log("Lobiye Girildi");
       PhotonNetwork.JoinOrCreateRoom("Oda", new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true }, TypedLobby.Default);
    }*/

    public override void OnJoinedRoom()
    {
        Debug.Log("Odaya girildi");

       GameObject Oyuncu = PhotonNetwork.Instantiate("Player", new Vector2(7,0), Quaternion.identity, 0, null);
        Oyuncu.GetComponent<PhotonView>().Owner.NickName = Random.Range(1, 100) + "misafir";
      
     
    }



    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        GameObject.FindWithTag("Player").GetComponent<PhotonView>().RPC("oyuncu_kacti", RpcTarget.All,null);
    }

    public override void OnLeftLobby()
    {
        Debug.Log("Lobiden Çýkýldý");
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Menu");
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
