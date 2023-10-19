using System;
using UI;
using UnityEngine;
using Zenject;
using Maze;
using UniRx;

namespace Props.Player.States
{
    public class PlayerMove : State
    { 
        private float _speed;
        private FieldLimits _fieldLimits;

        private Player _player;

        private ReactiveProperty<float> _lastSpeedRatio = new ReactiveProperty<float>(0);

        private ReactiveProperty<Vector2> _lastDirection = new ReactiveProperty<Vector2>();

        internal PlayerMove(
            FieldLimits fieldLimits,
            Player player,
            PlayerDirectionInput directionInput,
            Settings settings)
        {
            _fieldLimits = fieldLimits;
            _player = player;
            
            _speed = settings.Speed;

            CreateSubscribions(directionInput);
        }

        private void CreateSubscribions(PlayerDirectionInput directionInput)
        {
            directionInput.Direction
                .Where(direction => _lastDirection.Value != direction && direction != Vector2.zero)
                .Subscribe(direction => _lastDirection.Value = direction);
            directionInput.SpeedRatio
                .Subscribe(speedRatio => _lastSpeedRatio.Value = speedRatio);

            _lastDirection
                .Where(x => x != Vector2.zero)
                .Subscribe(direction => _player.Transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg));
        }

        private void Move(float speedRatio)
        {
            Vector3 moveToPosition = _player.Position + _lastDirection.Value * _speed * speedRatio * Time.deltaTime;
            _player.Position = _fieldLimits.ClampPlayerPosition(moveToPosition);
        }

        public override void Update()
        {
            if (!IsForwardAnyObstacles())
            {
                Move(_lastSpeedRatio.Value);
            }
        }

        private bool IsForwardAnyObstacles()
        {
            RaycastHit hit;
            if (Physics.Raycast(_player.Position, _lastDirection.Value, out hit, 93.1f))
            {
                if (hit.distance <= 0.5f)
                {
                    return true;
                }
            }
            return false;
        }

        [Serializable]
        public class Settings
        {
            public float Speed;
        }

        public class Factory : PlaceholderFactory<PlayerMove>
        {

        }
    }
}
