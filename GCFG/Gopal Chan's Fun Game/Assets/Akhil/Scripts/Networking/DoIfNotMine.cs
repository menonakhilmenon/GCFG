using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

namespace GCFG
{
    public class DoIfNotMine : MonoBehaviourPun
    {
        [SerializeField]
        private UnityEvent ifNotMineCallback = null;
        [SerializeField]
        private UnityEvent ifMineCallback = null;
        private void Start()
        {
            if (!photonView.IsMine) 
            {
                ifNotMineCallback?.Invoke();
            }
            else 
            {
                ifMineCallback?.Invoke();
            }
        }
    }
}