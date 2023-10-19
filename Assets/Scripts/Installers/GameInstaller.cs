using Zenject;
using Props.Player.Spawners;
using Props.Player;
using System;
using UnityEngine;

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
            Container.BindFactory<Player, Player.Factory>()
                    .FromComponentInNewPrefab(_settings.PlayerPrefab)
                    .UnderTransformGroup("Players")
                    .WhenInjectedInto<PlayerSpawner>();
        }

        [Serializable]
        public class Settings
        {
            public GameObject PlayerPrefab;
        }
    }
}