using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GCFG
{
    public class GameOverManager : MonoBehaviour
    {
        [SerializeField]
        private TMPro.TMP_Text winnerText = null;

        [SerializeField]
        private PlayerEvent playerWonEvent = null;

        public void CheckGameOver()
        {
            foreach (var player in PhotonNetwork.PlayerList)
            {
                var tower = PlayerManager.instance.GetPlayerTower(player);
                if (tower.Progression >= tower.MaxProgression)
                {
                    OnGameOver(player);
                    playerWonEvent?.InvokeWithPlayer(player);
                }
            }
        }

        public void OnGameOver(Player player) 
        {
            if(player == PhotonNetwork.LocalPlayer) 
            {
                SetWinner();
            }
            else 
            {
                SetLoser(player);
            }
        }

        private void SetLoser(Player player)
        {
            winnerText.text = $"Player {player.NickName} has won the game..";
        }

        private void SetWinner()
        {
            winnerText.text = $"Congrats you win!!";
        }
    }
}