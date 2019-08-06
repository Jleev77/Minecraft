using Entitas;
using System;
using System.Collections.Generic;

namespace Assets.ECS.Systems
{
    public class RenderPositionSystem : ReactiveSystem<GameEntity>
    {
        public RenderPositionSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.view.View.transform.localPosition = entity.position.Value;
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView && entity.hasPosition;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Position);
        }
    }
}
