using Photon.Pun;
using Props.Shared.Interfaces;
using Props.Shared.States;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Props.Shared
{
    public abstract class PropBase<StateType> : MonoBehaviour where StateType : Enum
    {
        [SerializeField]
        protected StateType[] startStatesTypes;

        private Rigidbody _rigidbody;

        private List<State> _currentStates = new List<State>();

        [Inject]
        private IHashSpawner<StateType> _statesSpawner;

        public Vector2 Position { get => transform.position; set => transform.position = value; }
        public Transform Transform { get => transform; }

        public Quaternion Rotation { get => transform.rotation; set => transform.rotation = value; }
        public Rigidbody Rigidbody { get => _rigidbody; }

        [Inject]
        private void Construct()
        {
            _rigidbody = GetComponent<Rigidbody>();

            Debug.Log($"Photon view is mine ${GetComponent<PhotonView>().IsMine}");
            if (GetComponent<PhotonView>().IsMine)
            {
                ChangeState(startStatesTypes);
            }
        }

        private void Update()
        {
            foreach (State state in _currentStates)
            {
                state.Update();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            foreach (State state in _currentStates)
            {
                state.OnTriggerEnter(other);
            }
        }

        public void ChangeState(params StateType[] types)
        {

            foreach (State state in _currentStates)
            {
                if (state != null)
                {
                    state.Dispose();
                }

            }

            _currentStates.Clear();

            if (types == null)
            {
                return;
            }

            foreach (StateType stateType in types)
            {
                State newState = _statesSpawner.GetState(stateType);
                newState.Start();
                _currentStates.Add(newState);
            }
        }
    }
}
