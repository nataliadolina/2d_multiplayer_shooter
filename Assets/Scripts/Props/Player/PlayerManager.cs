using Props.Player.Spawners;
using Props.Shared;
using UnityEngine;
using Zenject;

namespace Props.Player
{
    public class PlayerManager : PropBase<PlayerStateTypes>
    {
        private Vector2 _direction = Vector2.left;
        public Vector2 Direction { get => _direction; 
            set
            { 
                if (value != Vector2.zero && value != _direction)
                {
                    _direction = value;
                }
            }
        }


        private void Start()
        {
            ChangeState(startStatesTypes);
        }

        public class Factory : PlaceholderFactory<UnityEngine.Object, PlayerManager>
        {

        }
    }
}
