using System.Collections.Generic;
using Assets.ECS.Components;
using Entitas;
using UnityEngine;

namespace Assets.ECS.Systems
{
    public class ConvertToItemSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _context;

        public ConvertToItemSystem(Contexts contexts) : base(contexts.game)
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
                
                e.ReplaceRotate(new UnityEngine.Vector3(0, 50F, 0));
                e.ReplaceSize(e.originalSize.Size * .3f);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameObjectType && entity.gameObjectType.Value == GameObjectType.WorldItem;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameObjectType);
        }
    }
}
