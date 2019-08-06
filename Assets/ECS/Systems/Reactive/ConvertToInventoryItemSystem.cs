using System.Collections.Generic;
using Assets.ECS.Components;
using Entitas;
using UnityEngine;

namespace Assets.ECS.Systems
{
    public class ConvertToInventoryItemSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _context;

        public ConvertToInventoryItemSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts.game;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var e in entities)
            {
                e.view.View.SetActive(false);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameObjectType && entity.gameObjectType.Value == GameObjectType.InventoryItem;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameObjectType);
        }
    }
}
