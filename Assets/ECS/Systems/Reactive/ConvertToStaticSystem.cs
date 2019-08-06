using System.Collections.Generic;
using Assets.ECS.Components;
using Entitas;
using UnityEngine;

namespace Assets.ECS.Systems
{
    public class ConvertToStaticSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _context;

        public ConvertToStaticSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts.game;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var e in entities)
            {
                e.view.View.SetActive(true);

                var rb = e.view.View.GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.isKinematic = true;
                e.view.View.transform.rotation = Quaternion.identity;
                if(e.hasRotate) e.RemoveRotate();
                e.ReplacePosition(new Vector3(Mathf.Ceil(e.position.Value.x), Mathf.Ceil(e.position.Value.y), Mathf.Ceil(e.position.Value.z)));
                e.ReplaceSize(e.originalSize.Size);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameObjectType && entity.gameObjectType.Value == GameObjectType.Static;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameObjectType);
        }
    }
}
