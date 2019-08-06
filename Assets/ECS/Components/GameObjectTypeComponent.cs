using Entitas;

namespace Assets.ECS.Components
{
    public class GameObjectTypeComponent : IComponent
    {
        public GameObjectType Value;
    }
        public enum GameObjectType
    {
        Dynamic,
        Static,
        WorldItem,
        InventoryItem
    }
}
