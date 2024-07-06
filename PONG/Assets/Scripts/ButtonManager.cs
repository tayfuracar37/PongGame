using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public TextMeshProUGUI icerikText;
    public TMP_InputField icerik_text_input;


    public PhotonView pw;


    public void Lobi()
    {
        PhotonNetwork.LeaveLobby();
        SceneManager.LoadScene("Menu");
    }

    public void yazi_gonder()
    {
        string mesaj = icerik_text_input.text;
        pw.RPC("yazi_goster", RpcTarget.All,mesaj);

        icerik_text_input.text = null;
    }

    [PunRPC]
    public void yazi_goster(string mesaj)
    {
        icerikText.text = mesaj;
        Invoke("yazi_sil", 4f);
    }

    void yazi_sil()
    {
        icerikText.text = null;
    }



}
