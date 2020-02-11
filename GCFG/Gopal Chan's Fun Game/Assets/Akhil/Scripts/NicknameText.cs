using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

[RequireComponent(typeof(TMP_Text))]
public class NicknameText : MonoBehaviour
{
    [SerializeField]
    private PhotonView photonView = null;
    private void OnEnable()
    {
        GetComponent<TMP_Text>().text = photonView.Owner.NickName;
    }
}
