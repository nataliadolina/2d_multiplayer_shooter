using System;
using UnityEngine;

namespace Props.Shared.States
{
    public abstract class State : IDisposable
    {
        public virtual void SetUp(params object[] parametres)
        {

        }

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
