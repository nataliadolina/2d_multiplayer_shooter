using UnityEngine;

namespace UI
{
    public enum ZoneType
    {
        JoystickZone,
        ShootZone
    }

    public class UIRectangleZone : MonoBehaviour
    {
        [SerializeField]
        public ZoneType ZoneType;

        [Header("Bounds transforms")]
        [SerializeField]
        private RectTransform left;
        [SerializeField]
        private RectTransform right;
        [SerializeField]
        private RectTransform down;
        [SerializeField]
        private RectTransform up;

        public bool IsPositionInsideZone(Vector2 position)
        {
            float maxPositionX = left.position.x;
            float minPositionX = right.position.x;
            float minPositionY = down.position.y;
            float maxPositionY = up.position.y;

            return position.x > minPositionX && position.x < maxPositionX && position.y > minPositionY && position.y < maxPositionY;
        }
    }
}
