using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using Props.Player;
using UnityEngine;
using Zenject;
using Installers;


namespace Events
{
    public class CreateEventReceiver : MonoBehaviour, IOnEventCallback
    {
        [Inject]
        private PlayerManager.Factory _playerFactory;
        [Inject]
        private GameInstaller.Settings _settings;
        [Inject]
        private DiContainer _container;

        private void Awake()
        {
            PhotonNetwork.AddCallbackTarget(this);
        }

        private void OnDisable()
        {
            Debug.Log("On enable");
            //PhotonNetwork.RemoveCallbackTarget(this);
        }

        public void OnEvent(EventData photonEvent)
        {
            Debug.Log("OnEvent");
            if (photonEvent.Code == Events.EventCode.CustomManualInstantiationEventCode)
            {
                Debug.Log("network spawn");
                object[] data = (object[])photonEvent.CustomData;

                Vector3 position = (Vector3)data[0];
                Quaternion rotation = (Quaternion)data[1];

                PlayerManager player = _container.InstantiatePrefabForComponent<PlayerManager>(_settings.PlayerPrefab);
                Debug.Log(player);
                PhotonView photonView = player.GetComponent<PhotonView>();
                photonView.ViewID = (int)data[2];
            }
        }
    }
}
