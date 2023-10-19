using ModestTree;
using Props.Player.States;


namespace Props.Player.Spawners
{
    internal enum PlayerStateTypes
    {
        PlayerMove
    }

    internal class PlayerStatesSpawner
    {
        private PlayerMove.Factory _playerMoveFactory;

        internal PlayerStatesSpawner(PlayerMove.Factory playerMoveFactory)
        {
            _playerMoveFactory = playerMoveFactory;
        }

        public State CreateState(PlayerStateTypes playerStateTypes)
        {
            switch (playerStateTypes)
            {
                case PlayerStateTypes.PlayerMove:
                    return _playerMoveFactory.Create();
            }

            throw Assert.CreateException();
        }
    }
}