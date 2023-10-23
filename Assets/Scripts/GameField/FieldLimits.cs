using UnityEngine;
using Zenject;

namespace GameField
{
    public class FieldLimits : MonoBehaviour
    {
        [SerializeField]
        private float xLimitOffset;
        [SerializeField]
        private float yLimitOffset;

        private float _minX;
        private float _maxX;
        private float _minY;
        private float _maxY;

        public Vector2 XBounds => new Vector2(_minX, _maxX);
        public Vector2 YBounds => new Vector2(_minY, _maxY);

        [Inject]
        private void Construct()
        {
            _minX = GetUpLeft().x;
            _maxX = GetUpRight().x;
            _minY = GetDownLeft().y;
            _maxY = GetUpLeft().y;
        }

        internal Vector2 ClampPlayerPosition(Vector2 playerPosition)
        {
            return new Vector2(Mathf.Clamp(playerPosition.x, _minX, _maxX), Mathf.Clamp(playerPosition.y, _minY, _maxY));
        }

        internal bool IsPositionInsideZone(Vector2 position)
        {
            return position.x > _minX && position.x < _maxX && position.y > _minY && position.y < _maxY;
        }

        private Vector2 GetUpLeft()
        {
            Vector3 position = transform.position;
            float x = position.x - xLimitOffset;
            float y = position.y + yLimitOffset;
            return new Vector2(x, y);
        }

        private Vector2 GetDownLeft()
        {
            Vector3 position = transform.position;
            float x = position.x - xLimitOffset;
            float y = position.y - yLimitOffset;
            return new Vector3(x, y);
        }

        private Vector2 GetUpRight()
        {
            Vector3 position = transform.position;
            float x = position.x + xLimitOffset;
            float y = position.y + yLimitOffset;
            return new Vector3(x, y);
        }

        private Vector3 GetDownRight()
        {
            Vector3 position = transform.position;
            float x = position.x + xLimitOffset;
            float y = position.y - yLimitOffset;
            return new Vector3(x, y);
        }

#if UNITY_EDITOR

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(GetUpLeft(), GetDownLeft());
            Gizmos.DrawLine(GetUpRight(), GetDownRight());
            Gizmos.DrawLine(GetUpLeft(), GetUpRight());
            Gizmos.DrawLine(GetDownLeft(), GetDownRight());
        }

#endif
    }
}
