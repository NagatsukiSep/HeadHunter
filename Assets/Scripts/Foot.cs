using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
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
            Debug.Log(other.gameObject.name);
            other.gameObject.GetComponentInParent<Player>().Death();
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
