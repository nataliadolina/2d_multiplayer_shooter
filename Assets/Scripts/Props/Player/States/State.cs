using System;
using UnityEngine;

namespace Props.Player.States 
{
    public abstract class State : IDisposable
    {
        public virtual void Update() { }

        public virtual void Start()
        {
            // optionally overridden
        }

        public virtual void Dispose()
        {
            // optionally overridden
        }

        public virtual void OnTriggerEnter(Collider other)
        {
            // optionally overridden
        }
    }
}
