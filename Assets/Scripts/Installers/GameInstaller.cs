using Zenject;
using Props.Player.Spawners;
using Props.Player;
using System;
using UnityEngine;
using Props.Shared.Spawners;
using Events;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Inject]
        private Settings _settings = null;

        public override void InstallBindings()
        {
            InstallPlayer();
        }

        private void InstallPlayer()
        {
            Container.Bind<PlayerSpawner>().AsSingle().NonLazy();
            Container.BindFactory<UnityEngine.Object, PlayerManager, PlayerManager.Factory>()
                .FromFactory<PhotonFactory<PlayerManager>>();
        }

        [Serializable]
        public class Settings
        {
            public GameObject PlayerPrefab;
            public GameObject BulletPrefab;
        }
    }
}
