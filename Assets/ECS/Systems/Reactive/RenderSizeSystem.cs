using Entitas;
using System;
using System.Collections.Generic;

namespace Assets.ECS.Systems
{
    public class RenderSizeSystem : ReactiveSystem<GameEntity>
    {
        public RenderSizeSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.view.View.transform.localScale = entity.size.Size;
                if(!entity.hasOriginalSize){
                    entity.AddOriginalSize(entity.size.Size);
                }
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasView && entity.hasSize;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Size);
        }
    }
}
