using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UI;
using UniRx;

namespace Props.Player.States
{
    public class PlayerShoot : State
    {
        [Inject]
        private TouchController touchController;

        private PlayerShoot()
        {
            touchController.Shoot
                .Where(_ => _ == true)
                .Subscribe(_ => Debug.Log("shoot"));
        }
    }
}
