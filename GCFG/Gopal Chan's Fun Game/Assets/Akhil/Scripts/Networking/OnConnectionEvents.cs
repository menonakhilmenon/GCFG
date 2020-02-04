using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GCFG
{
    public class OnConnectionEvents : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent onRoomJoined = null;

        [SerializeField]
        private UnityEvent onRoomFull = null;

        void OnEnable()
        {
            Launcher.OnRoomJoinedCallback += () =>
            {
                onRoomJoined?.Invoke();
            };
            Launcher.OnRoomFullCallback += () =>
            {
                onRoomFull?.Invoke();
            };
        }
    }
}