using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Assets.ECS.Systems
{
    public class InitPlayerCamera : ReactiveSystem<GameEntity>
    {
        private GameContext _context;

        public InitPlayerCamera(Contexts contexts) : base(contexts.game)
        {
            _context = contexts.game;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach(var e in entities)
            {
                var camera = e.view.View.GetComponentInChildren<Camera>();

                var cameraEntity = _context.SetPlayerCamera(camera);
                cameraEntity.AddView(camera.gameObject);
                cameraEntity.AddPosition(camera.transform.localPosition);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer && entity.hasView;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Player);
        }
    }
}
