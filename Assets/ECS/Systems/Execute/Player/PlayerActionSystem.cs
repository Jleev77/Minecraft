
using Assets.ECS.Components;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Assets.ECS.Systems
{
    public class PlayerActionSystem : IExecuteSystem
    {
        private GameContext _context;

        public PlayerActionSystem(Contexts context)
        {
            _context = context.game;
        }

        public void Execute()
        {
            RaycastHit raycastHit;
            if (Input.GetKeyDown(KeyCode.Mouse0) && getRaycastHit(out raycastHit))
            {
                var link = raycastHit.transform.GetComponent<EntityLink>();
                ((GameEntity)link.entity).ReplaceGameObjectType(GameObjectType.WorldItem);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1) && getRaycastHit(out raycastHit))
            {
                var link = raycastHit.transform.GetComponent<EntityLink>();
                ((GameEntity)link.entity).ReplaceGameObjectType(GameObjectType.Static);
            }
        }

        private bool getRaycastHit(out RaycastHit raycastHit){
            var camera = _context.playerCamera.Value;
            var ray = camera.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
            return Physics.Raycast(ray, out raycastHit, 4f);
        }
    }
}
