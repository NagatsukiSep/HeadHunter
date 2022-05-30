using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Foot : MonoBehaviourPunCallbacks
{
    private MyPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<MyPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Body")
        {
            player.isGrounded = true;
        }
        if (other.gameObject.tag == "Head")
        {
            other.gameObject.GetComponentInParent<MyPlayer>().Death();
            if (player.photonView.IsMine)
            {
                PhotonNetwork.LocalPlayer.AddScore(1);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Body")
        {
            player.isGrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Body")
        {
            player.isGrounded = false;
        }
    }
}
