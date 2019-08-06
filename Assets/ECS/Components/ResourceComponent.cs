using Entitas;
using UnityEngine;

namespace Assets.ECS.Components
{
    public struct ResourceComponent : IComponent
    {
        public GameObject Prefab;
        public Material Material;
    }
}
