using UnityEngine;
using Props.Player.States;
using Zenject;
using Props.Player.Spawners;

namespace Props.Player
{
    public class Player : MonoBehaviour
    {
        public Vector2 Position { get => transform.position; set => transform.position = value; }
        public Transform Transform { get => transform; }

        public Rigidbody Rigidbody { get => _rigidbody; }

        private State _currentState;
        private Rigidbody _rigidbody;

        [Inject]
        private PlayerStatesSpawner _playerStatesSpawner;

        [Inject]
        private void Construct()
        {
            _rigidbody = GetComponent<Rigidbody>();
            ChangeState(PlayerStateTypes.PlayerMove);
        }

        private void Update()
        {
            _currentState.Update();
        }

        private void OnTriggerEnter(Collider other)
        {
            _currentState.OnTriggerEnter(other);
        }

        private void ChangeState(PlayerStateTypes type)
        {
            if (_currentState != null)
            {
                _currentState.Dispose();
                _currentState = null;
            }

            _currentState = _playerStatesSpawner.CreateState(type);
            _currentState.Start();
        }

        public class Factory : PlaceholderFactory<Player>
        {

        }
    }
}
