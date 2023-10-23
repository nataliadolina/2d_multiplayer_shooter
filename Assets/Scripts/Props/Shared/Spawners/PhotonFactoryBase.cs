using UnityEngine;
using Zenject;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Installers;
using System.Linq;
using System;

namespace Props.Shared.Spawners
{
    public class PhotonFactory<TFactoryOwner> : IFactory<UnityEngine.Object, TFactoryOwner>
        where TFactoryOwner : Component
    {
        readonly DiContainer _container;

        public PhotonFactory(DiContainer container)
        {
            _container = container;
        }

        public TFactoryOwner Create(UnityEngine.Object prefab)
        {
            TFactoryOwner owner = _container.InstantiatePrefabForComponent<TFactoryOwner>(prefab);
            PhotonView photonView = owner.gameObject.GetComponent<PhotonView>();

            object[] data = new object[]
                {
                    owner.transform.position, owner.transform.rotation, photonView.ViewID
                };

            RaiseEventOptions raiseEventOptions = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others,
                CachingOption = EventCaching.AddToRoomCache
            };

            SendOptions sendOptions = new SendOptions
            {
                Reliability = true
            };

            PhotonNetwork.RaiseEvent(Events.EventCode.CustomManualInstantiationEventCode,
                data,
                raiseEventOptions,
                sendOptions);
            Debug.Log("Sent event");
            return owner;
        }
    }
}