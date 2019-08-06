using System.Collections.Generic;
using Assets.ECS.Components;
using Entitas;
using UnityEngine;

namespace Assets.ECS.Systems
{
    public class WorldItemCollectorSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _context;

        public WorldItemCollectorSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts.game;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var e in entities)
            {
                e.view.View.AddComponent<CollisionList>();
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasContainer && entity.isWorldItemCollector && entity.hasView;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.WorldItemCollector, GameMatcher.Container));
        }
    }
}
