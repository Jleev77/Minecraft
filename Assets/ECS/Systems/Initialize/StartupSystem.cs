using Assets.ECS.Components;
using Entitas;
using System;

namespace Assets.ECS.Systems
{
    public class StartupSystem : IInitializeSystem
    {
        private GameContext _context;

        public StartupSystem(Contexts contexts)
        {
            _context = contexts.game;
        }
        public void Initialize()
        {
            var _ = _context.gameSetup.value;

            createBlocks(new UnityEngine.Vector3Int(10, 10, 10), new UnityEngine.Vector3Int(0, -10, 0));

            var player = _context.CreateEntity();
            player.isPlayer = true;
            player.AddResource(_.Player, _.Grey);
            player.AddGameObjectType(GameObjectType.Dynamic);
            player.AddPosition(new UnityEngine.Vector3(1, 2, 1));
            player.AddSize(new UnityEngine.Vector3(1, 1, 1));
            player.AddMoveSpeed(10f);
            player.AddContainer(new GameEntity[9]);
            player.isWorldItemCollector = true;
        }

        private void createBlocks(UnityEngine.Vector3Int numBlocks, UnityEngine.Vector3Int startPositions = default)
        {
            var _ = _context.gameSetup.value;
            Random random = new Random();
            var materials = new[] { _.Brown, _.Green, _.Grey };
            int length = materials.Length;

            for (int x = startPositions.x; x < numBlocks.x + startPositions.x; x++)
            {
                for (int y = startPositions.y; y < numBlocks.y + startPositions.y; y++)
                {
                    for (int z = startPositions.z; z < numBlocks.z + startPositions.z; z++)
                    {
                        var block = _context.CreateEntity();
                        block.AddResource(_.BlankBlock, materials[random.Next(length)]);
                        block.AddName(block.resource.Material.name);
                        block.AddGameObjectType(GameObjectType.Static);
                        block.AddPosition(new UnityEngine.Vector3(x, y, z));
                        block.AddSize(new UnityEngine.Vector3(1, 1, 1));
                        block.AddStackSize(64);
                        //block.AddRotate(180f, new UnityEngine.Vector3(random.Next(2), random.Next(2), random.Next(2)));
                    }
                }
            }
        }
    }
}
