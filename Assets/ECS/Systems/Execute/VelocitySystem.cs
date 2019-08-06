using Entitas;
using UnityEngine;

namespace Assets.ECS.Systems
{
    public class VelocitySystem : IExecuteSystem
    {
        private GameContext _context;
        private IGroup<GameEntity> _group;

        public VelocitySystem(Contexts contexts)
        {
            _context = contexts.game;
            _group = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Velocity));
        }

        public void Execute()
        {
            foreach(var e in _group.GetEntities())
            {
                e.ReplacePosition(e.position.Value + (e.velocity.Value * Time.deltaTime));
            }
        }
    }
}
