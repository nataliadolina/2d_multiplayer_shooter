using Props.Bullet.Spawners;
using Props.Shared;
using Zenject;
using UnityEngine;
using Props.Player;

namespace Props.Bullet
{
    public class BulletManager : PropBase<BulletStateType>
    {
        public class Pool : MemoryPool<BulletManager>
        {
            [Inject]
            private PlayerManager _player;

            protected override void OnCreated(BulletManager item)
            {
                item.gameObject.SetActive(false);
                item.Transform.parent = _player.Transform;
                item.Transform.localPosition = Vector2.zero;
            }

            protected override void OnSpawned(BulletManager item)
            {
                item.gameObject.SetActive(true);
                item.Transform.parent = null;
            }

            protected override void OnDespawned(BulletManager item)
            {
                item.gameObject.SetActive(false);
                item.Transform.parent = _player.Transform;
                item.Transform.localPosition = Vector2.zero;
            }
        }
    }
}
