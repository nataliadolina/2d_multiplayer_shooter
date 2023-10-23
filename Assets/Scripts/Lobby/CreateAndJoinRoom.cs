using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Lobby
{
    public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private TMP_InputField createRoomName;
        [SerializeField]
        private TMP_InputField joinRoomName;
        
        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(createRoomName.text);
        }

        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(joinRoomName.text);
        }

        public override void OnJoinedRoom()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
