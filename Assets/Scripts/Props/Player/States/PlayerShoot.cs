using Zenject;
using UI;
using UniRx;
using Props.Bullet;
using Props.Shared.States;
using Props.Bullet.Spawners;

namespace Props.Player.States
{
    public class PlayerShoot : State
    {
        private BulletManager.Pool _bulletPool;
        private TouchController _touchController;

        public PlayerShoot(TouchController touchController,
            BulletManager.Pool bulletPool)
        {
            _bulletPool = bulletPool;
            _touchController = touchController;
            touchController.Shoot
                .Where(_ => _ == true)
                .Subscribe(_ => EmitBullet());
        }

        private void EmitBullet()
        {
            BulletManager bullet = _bulletPool.Spawn();
            _touchController.Shoot.Value = false;
        }

        public class Factory : PlaceholderFactory<PlayerShoot>
        {

        }
    }
}
