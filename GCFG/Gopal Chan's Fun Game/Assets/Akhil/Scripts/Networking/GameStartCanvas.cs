using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    public class GameStartCanvas : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] gameObjectsToDisableOnJoined = null;
        [SerializeField]
        private GameObject[] gameObjectsToDisableOnRoomFull= null;
        // Start is called before the first frame update
        void OnEnable()
        {
            Launcher.OnRoomJoinedCallback += () =>
            {
                foreach (var obj in gameObjectsToDisableOnJoined)
                {
                    obj.SetActive(false);
                };
            };
            Launcher.OnRoomFullCallback += () =>
            {
                foreach (var obj in gameObjectsToDisableOnRoomFull)
                {
                    obj.SetActive(false);
                };
            };
        }
    }
}