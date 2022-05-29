using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private bool isBot = false;
    private Rigidbody2D rb;
    [SerializeField] public bool isGrounded = false;
    [SerializeField] public bool isAlive = true;

    // [SerializeField] private GameObject foot;
    [SerializeField] private GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBot)
        {
            Jump();
            Move();
        }
    }

    private void Move()
    {

        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * 5, rb.velocity.y);


    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * 10;
        }
    }

    public void Death()
    {
        isAlive = false;
        head.SetActive(false);

    }
}
