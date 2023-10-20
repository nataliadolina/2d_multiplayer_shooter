using Props.Player.States;
using Props.Shared.Spawners;
using Zenject;

namespace Props.Player.Spawners
{
    public enum PlayerStateTypes
    {
        PlayerMove = 1,
        PlayerShoot = 2,
    }

    public class PlayerStateSpawner : SpawnerBase<PlayerStateTypes>
    {
        [Inject]
        private PlayerMove.Factory _playerMoveFactory;
        [Inject]
        private PlayerShoot.Factory _playerShootFactory;

        public PlayerStateSpawner(
            PlayerMove.Factory playerMoveFactory,
            PlayerShoot.Factory playerShootFactory)
        {
            _playerMoveFactory = playerMoveFactory;
            _playerShootFactory = playerShootFactory;
            Init();
        }

        protected override void SetStatesMap()
        {
            _statesMap.Add(PlayerStateTypes.PlayerMove, _playerMoveFactory.Create());
            _statesMap.Add(PlayerStateTypes.PlayerShoot, _playerShootFactory.Create());
        }
    }
}