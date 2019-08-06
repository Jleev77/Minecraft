using System.Collections.Generic;
using Assets.ECS.Components;
using Entitas;
using UnityEngine;

namespace Assets.ECS.Systems
{
    public class ConvertToDynamicSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _context;

        public ConvertToDynamicSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts.game;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var e in entities)
            {
                e.view.View.SetActive(true);

                var rb = e.view.View.GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.isKinematic = false;

                if(e.hasRotate) e.RemoveRotate();
                e.ReplaceSize(e.originalSize.Size);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameObjectType && entity.gameObjectType.Value == GameObjectType.Dynamic;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameObjectType);
        }
    }
}
