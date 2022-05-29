using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class NameButton : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        PhotonNetwork.NickName = inputField.text;
    }
}
