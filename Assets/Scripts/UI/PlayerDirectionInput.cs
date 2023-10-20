using System;
using UnityEngine;
using UniRx;

namespace UI
{
    public class PlayerDirectionInput : JoystickControllerBase
    {
        public ReactiveProperty<Vector2> Direction = new ReactiveProperty<Vector2>();
        public ReactiveProperty<float> SpeedRatio = new ReactiveProperty<float>();
        private protected override void UpdatePlayerDirection(in Vector2 direction)
        {
            Direction.Value = direction;
            SpeedRatio.Value = direction.sqrMagnitude;
        }
    }
}
