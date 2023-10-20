using Props.Shared.States;
using System;

namespace Props.Shared.Interfaces
{
    public interface IHashSpawner<StateType> where StateType : Enum
    {
        public State GetState(StateType type);
    }
}
