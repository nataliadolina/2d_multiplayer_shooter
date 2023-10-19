using Props.Player.Spawners;
using Props.Player.States;
using Zenject;
using System;
using UnityEngine;

namespace Props.Player.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField]
        private Player player;

        public override void InstallBindings()
        {
            Container.BindInstance(player).AsSingle().NonLazy();
            Container.Bind<PlayerStatesSpawner>().AsSingle().NonLazy();
            Container.BindFactory<PlayerMove, PlayerMove.Factory>().WhenInjectedInto<PlayerStatesSpawner>();
        }
    }
}