using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Chat;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{

    public void oyun_sahnesi()
    {
        if (PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinOrCreateRoom("yeni oda", new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true }, TypedLobby.Default);
            SceneManager.LoadScene("Game");
        }
    }
   
}
