using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using ExitGames.Client.Photon;
using Photon.Realtime;
using static Score;

public class MyPlayer : MonoBehaviourPunCallbacks
{
    [SerializeField] private bool isBot = false;
    private Rigidbody2D rb;
    [SerializeField] public bool isGrounded = false;
    [SerializeField] public bool isAlive = true;
    [SerializeField] public int killCount = 0;

    [SerializeField] private GameObject foot;
    [SerializeField] private GameObject head;
    [SerializeField] private TextMeshProUGUI nameText;
    private float time = 0;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (photonView.IsMine)
        {
            PhotonNetwork.NickName = "Player" + Random.Range(0, 100);
        }
        if (!photonView.IsMine || isBot)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBot && photonView.IsMine)
        {
            Jump();
            Move();
            CheckNameChanged();
        }
        if (!isAlive && time > 2f)
        {
            Reborn();
        }
        time += Time.deltaTime;
    }

    private void Move()
    {
        float moveSpeed = isGrounded ? 10f : 5f;
        moveSpeed *= isAlive ? 1.5f : 2f;
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);


    }
    private void Jump()
    {
        float jumpPower = isAlive ? 15f : 20f;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.up * jumpPower;
            }
        }

    }

    public void Death()
    {
        time = 0;
        isAlive = false;
        head.SetActive(false);
        spriteRenderer.color = new Color(1, 1, 1, 0.2f);

    }

    private void Reborn()
    {
        isAlive = true;
        head.SetActive(true);
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    private void CheckNameChanged()
    {
        if (photonView.IsMine)
        {
            if (nameText.text != PhotonNetwork.NickName)
            {
                photonView.RPC("SetName", RpcTarget.AllBuffered);
            }
        }
    }
    [PunRPC]
    public void SetName()
    {
        nameText.text = photonView.Owner.NickName + " (" + photonView.Owner.GetScore().ToString() + ")";
    }
}
