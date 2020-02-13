using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GCFG
{
    [CreateAssetMenu(menuName ="Events/PlayerEvent")]
    public class PlayerEvent : ScriptableGameEvent
    {
        public void InvokeWithPlayer(Player player)
        {
            Invoke(player);
        }
    }
}