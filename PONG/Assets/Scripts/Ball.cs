using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class Ball : MonoBehaviour
{

    Rigidbody2D rb;
    PhotonView photonwiew;



    int oyuncu1_Skor = 0;
    int oyuncu2_Skor = 0;


    public TextMeshProUGUI Oyuncu1_Text;
    public TextMeshProUGUI Oyuncu2_Text;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        photonwiew = GetComponent<PhotonView>();

    }

    [PunRPC]
    public void Basla()
    {

        rb.velocity = new Vector2(5, 5);

        skor();

    }



    public void skor()
    {


        Oyuncu1_Text.text = PhotonNetwork.PlayerList[0].NickName + ":" + oyuncu1_Skor.ToString();
        Oyuncu2_Text.text = PhotonNetwork.PlayerList[1].NickName + ":" + oyuncu1_Skor.ToString();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (photonwiew.IsMine)
        {
            if (collision.gameObject.name == "ScoreDuvarPlayer")
            {
                photonwiew.RPC("gol", RpcTarget.All, 0, 1);
            }
            else if (collision.gameObject.name == "ScoreDuvarPlayer2")
            {
                photonwiew.RPC("gol", RpcTarget.All, 1, 0);
            }



        }
        
    }

    [PunRPC]
    public void gol(int oyuncubir,int oyuncuiki)
    {
        oyuncu1_Skor +=oyuncubir;
        oyuncu2_Skor += oyuncuiki;

        skor();

        Servis();
    }

    public void Servis()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        rb.velocity = new Vector2(5, 5);
    }

}
