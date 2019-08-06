using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Assets.ECS.Systems
{
    public class InitViewSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _context;
        private readonly Transform _transform;
        public InitViewSystem(Contexts contexts, Transform transform) : base(contexts.game)
        {
            _context = contexts.game;
            _transform = transform;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var entity in entities)
            {
                if (entity.hasView)
                {
                    Object.Destroy(entity.view.View);
                }
                var go = Object.Instantiate(entity.resource.Prefab, _transform);
                go.GetComponent<Renderer>().material = entity.resource.Material;
                entity.ReplaceView(go);
                go.Link(entity);

                var children = new List<GameEntity>();
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasResource;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Resource);
        }
    }
}
