using Entitas;
using UnityEngine;

namespace Assets.ECS.Systems
{
    public class RotateSystem : IExecuteSystem
    {
        private GameContext _context;
        private IGroup<GameEntity> _group;

        public RotateSystem(Contexts contexts)
        {
            _context = contexts.game;
            _group = _context.GetGroup(GameMatcher.Rotate);
        }

        public void Execute()
        {
            foreach(var entity in _group.GetEntities())
            {
                if (!entity.hasRotate || !entity.hasView) continue;

                var rotate = entity.rotate.Value;
                var transform = entity.view.View.transform;

                transform.Rotate(rotate * Time.deltaTime);
            }
        }
    }
}
