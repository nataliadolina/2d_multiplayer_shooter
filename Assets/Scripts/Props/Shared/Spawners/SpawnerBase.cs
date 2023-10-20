using ModestTree;
using Props.Shared.Interfaces;
using Props.Shared.States;
using System;
using System.Collections.Generic;

namespace Props.Shared.Spawners
{
    public abstract class SpawnerBase<StateType> : IHashSpawner<StateType> where StateType : Enum  
    {
        protected Dictionary<StateType, State> _statesMap = new Dictionary<StateType, State>();
        protected abstract void SetStatesMap();

        protected void Init()
        {
            SetStatesMap();
        }

        public State GetState(StateType stateType)
        {
            if (_statesMap.ContainsKey(stateType))
            {
                return _statesMap[stateType];
            }

            throw Assert.CreateException();
        }
    }
}
