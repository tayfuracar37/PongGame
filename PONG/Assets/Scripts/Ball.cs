using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    PhotonView photonView;

    int oyuncu1_Skor = 0;
    int oyuncu2_Skor = 0;

    public TextMeshProUGUI Oyuncu1_Text;
    public TextMeshProUGUI Oyuncu2_Text;
    public TextMeshProUGUI Timer_Text;

    private float countdown = 90f;
    private bool gameStarted = false;
    private bool gameEnded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        photonView = GetComponent<PhotonView>();

        if (PhotonNetwork.PlayerList.Length == 2)
        {
            photonView.RPC("StartGame", RpcTarget.AllBuffered);
        }
    }

    private void Update()
    {
        if (gameStarted && !gameEnded)
        {
            countdown -= Time.deltaTime;
            Timer_Text.text = "Time: " + Mathf.Ceil(countdown).ToString();

            if (countdown <= 0)
            {
                photonView.RPC("EndGame", RpcTarget.AllBuffered);
            }
        }
    }

    [PunRPC]
    public void StartGame()
    {
        gameStarted = true;
        Basla();
    }

    [PunRPC]
    public void EndGame()
    {
        gameEnded = true;
        rb.velocity = Vector2.zero;
        Timer_Text.text = "Game Over";
       
    }

    [PunRPC]
    public void Basla()
    {
        rb.velocity = new Vector2(5, 5);
        skor();
    }

    public void skor()
    {
        Oyuncu1_Text.text = PhotonNetwork.PlayerList[0].NickName + ": " + oyuncu1_Skor.ToString();
        Oyuncu2_Text.text = PhotonNetwork.PlayerList[1].NickName + ": " + oyuncu2_Skor.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (photonView.IsMine)
        {
            if (collision.gameObject.name == "ScoreDuvarPlayer")
            {
                photonView.RPC("gol", RpcTarget.AllBuffered, 0, 1);
            }
            else if (collision.gameObject.name == "ScoreDuvarPlayer2")
            {
                photonView.RPC("gol", RpcTarget.AllBuffered, 1, 0);
            }
        }
    }

    [PunRPC]
    public void gol(int oyuncubir, int oyuncuiki)
    {
        oyuncu1_Skor += oyuncubir;
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

    [PunRPC]
    public void oyuncu_kacti()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
}
