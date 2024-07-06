using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public float speed = 5f;
    private Rigidbody2D rb;
    PhotonView pw;

    public TextMeshProUGUI yazi_text;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pw = GetComponent<PhotonView>();
        variableJoystick = GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>();
        yazi_text = GameObject.Find("OyuncuBekleniyor").GetComponent<TextMeshProUGUI>();



        if (pw.IsMine)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                transform.position = new Vector2(7, 0);
                InvokeRepeating("OyuncuKontrol", 0f,0.5f);
            }
            else if (!PhotonNetwork.IsMasterClient)
            {
                transform.position = new Vector3(-7, 0);
            }
        }
    }


    void OyuncuKontrol()
    {
        if (PhotonNetwork.PlayerList.Length == 2)
        {
            pw.RPC("yazisil", RpcTarget.All, null);
            GameObject.Find("Ball").GetComponent<PhotonView>().RPC("Basla", RpcTarget.All, null);
            CancelInvoke("OyuncuKontrol");
        }
    }

    

    [PunRPC]
    public void yazisil()
    {
        yazi_text.text = null;
    }



   void Hareket()
    {
        if (pw.IsMine)
        {
            Vector2 direction = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical).normalized;
            rb.velocity = direction * speed;
        }
       
    }

    private void FixedUpdate()
    {
        Hareket();
    }
}
