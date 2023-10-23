using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Props.Shared.Spawners
{
    public interface INetworkSpawner
    {
        public GameObject Create();
    }
}
