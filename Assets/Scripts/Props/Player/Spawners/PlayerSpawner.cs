using GameField;
using UnityEngine;
using Photon.Pun;
using Props.Shared.Spawners;
using Installers;

namespace Props.Player.Spawners
{
    public class PlayerSpawner : INetworkSpawner
    {
        private PlayerManager.Factory _playerFactory;

        private float _minX;
        private float _maxX;

        private float _minY;
        private float _maxY;

        private GameObject _prefab;

        public PlayerSpawner(PlayerManager.Factory playerFactory, FieldLimits fieldLimits, GameInstaller.Settings settings)
        {
            _playerFactory = playerFactory;

            _minX = fieldLimits.XBounds.x + 2f;
            _maxX = fieldLimits.XBounds.y - 2f;
            _minY = fieldLimits.YBounds.x + 1f;
            _maxY = fieldLimits.YBounds.y - 1f;

            _prefab = settings.PlayerPrefab;
            Create();
        }

        public GameObject Create()
        {
            Vector2 position = new Vector2(Random.Range(_minX, _maxX), Random.Range(_minY, _maxY));
            PlayerManager player = _playerFactory.Create(_prefab);
            Debug.Log("created player");
            Debug.Log(_playerFactory);
            player.Position = position;
            return player.gameObject;
        }
    }
}
