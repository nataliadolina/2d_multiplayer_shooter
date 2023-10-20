using Props.Player.States;
using System;
using Zenject;
using UnityEngine;
using Props.Bullet.States;
using Props.Player.Installers;

namespace Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/new GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField]
        public GameInstaller.Settings GameSettings;

        [SerializeField]
        public PlayerSettings Player;

        [SerializeField]
        public BulletSettings Bullet;

        [Serializable]
        public class PlayerSettings
        {
            public PlayerMove.Settings StateMoving;
        }

        [Serializable]
        public class BulletSettings
        {
            public BulletMove.Settings StateMoving;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(Player.StateMoving);
            Container.BindInstance(Bullet.StateMoving);
            Container.BindInstance(GameSettings);
        }
    }
}

