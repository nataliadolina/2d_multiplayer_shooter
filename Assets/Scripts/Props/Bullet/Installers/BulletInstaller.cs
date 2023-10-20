using Props.Bullet.Spawners;
using Props.Bullet.States;
using Props.Player;
using Props.Shared.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Props.Bullet.Installers
{
    public class BulletInstaller : MonoInstaller
    {
        [SerializeField]
        private BulletManager bullet;
        public override void InstallBindings()
        {
            Container.BindInstance(bullet).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BulletStateSpawner>().AsSingle().NonLazy();
            Container.BindFactory<BulletMove, BulletMove.Factory>().WhenInjectedInto<BulletStateSpawner>();
        }
    }
}
