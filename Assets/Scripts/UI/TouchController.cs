using UnityEngine;
using UniRx.Triggers;
using UniRx;
using Zenject;
using System.Linq;

namespace UI
{
    public class TouchController : MonoBehaviour
    {
        [Inject]
        private PlayerDirectionInput _playerDirectionInput;

        public ReactiveProperty<bool> Shoot = new ReactiveProperty<bool>(false);

        [Inject]
        private void Construct(UIRectangleZone[] uiRectangleZones)
        {
            UIRectangleZone shootZone = uiRectangleZones.Where(x => x.ZoneType == ZoneType.ShootZone).FirstOrDefault();
            this.UpdateAsObservable()
                .Where(_ => Input.GetMouseButtonDown(0))
                .Where(_ => shootZone.IsPositionInsideZone(Input.mousePosition))
                .Subscribe(_ => Shoot.Value = true);

            this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => _playerDirectionInput.StartUpdateJoyctickDirection());

            this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonUp(0))
            .Subscribe(_ => _playerDirectionInput.ResetJoystick());

            this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButton(0))
            .Subscribe(x => _playerDirectionInput.SetKnobPosition());
        }
    }
}
