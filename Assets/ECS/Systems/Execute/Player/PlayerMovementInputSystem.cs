using Entitas;
using UnityEngine;

namespace Assets.ECS.Systems
{
    public class PlayerMovementInputSystem : IExecuteSystem
    {
        private GameContext _context;

        public PlayerMovementInputSystem(Contexts contexts)
        {
            _context = contexts.game;
        }

        public void Execute()
        {
            var playerEntity = _context.playerEntity;
            var playerCameraEntity = _context.playerCameraEntity;

            var playerTransform = playerEntity.view.View.transform;
            var cameraTransform = playerCameraEntity.view.View.transform;

            var moveSpeed = playerEntity.moveSpeed.Value;

            

            var horizontal = cameraTransform.right * Input.GetAxis("Horizontal");
            var vertical = cameraTransform.forward * Input.GetAxis("Vertical");
            var up = playerTransform.up * (Input.GetKey(KeyCode.Space)? 1f : 0f);
            var down = playerTransform.up * (Input.GetKey(KeyCode.X)? -1f : 0f);

            playerEntity.ReplaceVelocity((horizontal + vertical + up + down) * moveSpeed);



            var mouseX = Input.GetAxisRaw("Mouse X");
            playerEntity.ReplaceRotate(new Vector3(0, mouseX, 0) * 100);

            var mouseY = Input.GetAxisRaw("Mouse Y") * -1;
            playerCameraEntity.ReplaceRotate(new Vector3(mouseY, 0, 0) * 100);
        }
    }
}
