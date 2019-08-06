using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Assets.ECS.Systems
{
    class DestroyEntitySystem : ReactiveSystem<GameEntity>
    {
        public DestroyEntitySystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var entity in entities)
            {
                if (entity.hasView)
                {
                    entity.view.View.Unlink();
                    Object.Destroy(entity.view.View);
                }
                entity.Destroy();
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDestroyed;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Destroyed);
        }
    }
}
