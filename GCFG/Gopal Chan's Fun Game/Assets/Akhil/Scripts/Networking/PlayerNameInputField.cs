using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    [RequireComponent(typeof(TMPro.TMP_InputField))]
    public class PlayerNameInputField : MonoBehaviour
    {
        public void SetPlayerName()
        {
            PhotonNetwork.NickName = GetComponent<TMPro.TMP_InputField>().text;
        }
    }
}