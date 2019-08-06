using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Assets.ECS.Components
{
    [Unique]
    public class PlayerCameraComponent : IComponent
    {
        public Camera Value;
    }
}
