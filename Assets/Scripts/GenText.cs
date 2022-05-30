using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GenText : MonoBehaviourPunCallbacks
{
    public bool isPresenter = false;

    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private GameObject textPrefab;
    private float time = 0;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 7)
        {
            time = 0;
            if (isPresenter)
            {
                photonView.RPC(nameof(GenTxt), RpcTarget.All, index);
                index++;
            }
        }
    }

    [PunRPC]
    private void GenTxt(int i)
    {
        if (i >= sprites.Count)
        {
            return;
        }
        Debug.Log("Gen");
        var _text = Instantiate(textPrefab);
        _text.GetComponent<SpriteRenderer>().sprite = sprites[i];
        _text.AddComponent<BoxCollider2D>();
        _text.transform.position = new Vector3(10, 2 * ((i % 3) - 1), 0);
    }
}
