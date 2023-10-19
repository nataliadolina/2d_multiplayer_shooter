using Props.Player.States;
using System;
using Zenject;
using Maze;
using UnityEngine;
using UI;

namespace Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/new GameSettingsInstaller")]
    internal class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField]
        internal GameInstaller.Settings GameSettings;

        [SerializeField]
        internal PlayerSettings Player;

        [Serializable]
        internal class PlayerSettings
        {
            public PlayerMove.Settings StateMoving;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(Player.StateMoving);
            Container.BindInstance(GameSettings);
        }
    }
}

