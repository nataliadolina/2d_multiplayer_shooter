using System;
using Zenject;
using UnityEngine;
using Props.Player;
using Props.Shared.States;
using GameField;
using UI;

namespace Props.Bullet.States
{
    public class BulletMove : State
    {
        private float _speed;

        private PlayerManager _playerManager;
        [Inject]
        private BulletManager _bullet;
        [Inject]
        private BulletManager.Pool _bulletPool;
        [Inject]
        private FieldLimits _fieldLimits;

        private Vector2 _direction = Vector2.left;

        public BulletMove(
            PlayerManager playerManager,
            BulletManager bullet,
            Settings settings,
            BulletManager.Pool bulletPool,
            FieldLimits fieldLimits
            )
        {
            _speed = settings.Speed;
            _bullet = bullet;
            _bulletPool = bulletPool;
            _fieldLimits = fieldLimits;
            _playerManager = playerManager;
        }

        public override void Update()
        {
            if (_direction == Vector2.zero)
            {
                _direction = _playerManager.Direction.normalized;
                _bullet.Rotation = _playerManager.Rotation;
            }

            _bullet.Position += _direction * Time.deltaTime * _speed;

            if (!_fieldLimits.IsPositionInsideZone(_bullet.Position))
            {
                _direction = Vector2.zero;
                _bulletPool.Despawn(_bullet);
            } 
        }

        public override void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerManager>())
            {
                _bulletPool.Despawn(_bullet);
            }
        }

        [Serializable]
        public class Settings
        {
            public float Speed;
        }

        public class Factory : PlaceholderFactory<BulletMove> 
        {

        }
    }
}
