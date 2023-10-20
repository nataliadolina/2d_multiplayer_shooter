using Props.Player.Spawners;
using Props.Player.States;
using Zenject;
using System;
using UnityEngine;
using Props.Shared;
using Props.Bullet;
using Installers;

namespace Props.Player.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [Inject]
        private GameInstaller.Settings _settings;

        [SerializeField]
        private PlayerManager player;

        public override void InstallBindings()
        {
            Container.BindInstance(player).AsSingle().NonLazy();

            Container.BindMemoryPool<BulletManager, BulletManager.Pool>()
                .WithInitialSize(10)
                .WithMaxSize(15)
                .FromComponentInNewPrefab(_settings.BulletPrefab);

            Container.BindInterfacesAndSelfTo<PlayerStateSpawner>()
                .AsSingle()
                .NonLazy();

            Container.BindFactory<PlayerMove, PlayerMove.Factory>()
                .WhenInjectedInto<PlayerStateSpawner>();

            Container.BindFactory<PlayerShoot, PlayerShoot.Factory>()
                .WhenInjectedInto<PlayerStateSpawner>();
        }

    }
}