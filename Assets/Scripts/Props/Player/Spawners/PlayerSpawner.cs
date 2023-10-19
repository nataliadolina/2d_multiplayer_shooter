using UnityEngine;
using Zenject;

namespace Props.Player.Spawners
{
    public class PlayerSpawner
    {
        private Player.Factory _playerFactory;

        [Inject]
        private void Construct()
        {
            CreatePlayer();
        }

        public PlayerSpawner(Player.Factory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public Player CreatePlayer()
        {
            return _playerFactory.Create();
        }
    }
}
