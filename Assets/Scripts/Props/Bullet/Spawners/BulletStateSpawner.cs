using Props.Bullet.States;
using Props.Player;
using Props.Shared.Spawners;

namespace Props.Bullet.Spawners
{
    public enum BulletStateType
    {
        BulletMove
    }

    public class BulletStateSpawner : SpawnerBase<BulletStateType>
    {
        private BulletMove.Factory _bulletMoveStateFactory;
        private PlayerManager _playerManager;

        public BulletStateSpawner(
            BulletMove.Factory bulletMoveStateFactory,
            PlayerManager playerManager)
        {
            _playerManager = playerManager;
            _bulletMoveStateFactory = bulletMoveStateFactory;
            Init();
        }

        protected override void SetStatesMap()
        {
            _statesMap.Add(BulletStateType.BulletMove, _bulletMoveStateFactory.Create());
        }
    }
}
