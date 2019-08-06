using Assets.ECS.Systems;
using Assets.Scripts;
using Entitas;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameSetup _gameSetup;
    public Transform _transform;
    private Systems _systems;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        var contexts = Contexts.sharedInstance;
        contexts.game.SetGameSetup(_gameSetup);

        _systems = CreateSystems(contexts);

        _systems.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        _systems.Execute();
    }

    Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new StartupSystem(contexts))
            .Add(new InitViewSystem(contexts, _transform))
            .Add(new InitPlayerCamera(contexts))
            .Add(new RenderSizeSystem(contexts))
            .Add(new ConvertToStaticSystem(contexts))
            .Add(new ConvertToDynamicSystem(contexts))
            .Add(new ConvertToInventoryItemSystem(contexts))
            .Add(new ConvertToItemSystem(contexts))
            .Add(new RenderPositionSystem(contexts))
            .Add(new RotateSystem(contexts))
            .Add(new PlayerActionSystem(contexts))
            .Add(new PlayerMovementInputSystem(contexts))
            .Add(new VelocitySystem(contexts))
            .Add(new WorldItemCollectorSystem(contexts))
            .Add(new DestroyEntitySystem(contexts))
            ;
    }
}
