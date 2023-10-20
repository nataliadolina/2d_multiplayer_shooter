using UnityEngine;
using Zenject;

namespace Props.Player.Spawners
{
    public class PlayerSpawner
    {
        private PlayerManager.Factory _playerFactory;

        [Inject]
        private void Construct()
        {
            CreatePlayer();
        }

        public PlayerSpawner(PlayerManager.Factory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public PlayerManager CreatePlayer()
        {
            return _playerFactory.Create();
        }
    }
}
