//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameSetupEntity { get { return GetGroup(GameMatcher.GameSetup).GetSingleEntity(); } }
    public GameSetupComponent gameSetup { get { return gameSetupEntity.gameSetup; } }
    public bool hasGameSetup { get { return gameSetupEntity != null; } }

    public GameEntity SetGameSetup(Assets.Scripts.GameSetup newValue) {
        if (hasGameSetup) {
            throw new Entitas.EntitasException("Could not set GameSetup!\n" + this + " already has an entity with GameSetupComponent!",
                "You should check if the context already has a gameSetupEntity before setting it or use context.ReplaceGameSetup().");
        }
        var entity = CreateEntity();
        entity.AddGameSetup(newValue);
        return entity;
    }

    public void ReplaceGameSetup(Assets.Scripts.GameSetup newValue) {
        var entity = gameSetupEntity;
        if (entity == null) {
            entity = SetGameSetup(newValue);
        } else {
            entity.ReplaceGameSetup(newValue);
        }
    }

    public void RemoveGameSetup() {
        gameSetupEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GameSetupComponent gameSetup { get { return (GameSetupComponent)GetComponent(GameComponentsLookup.GameSetup); } }
    public bool hasGameSetup { get { return HasComponent(GameComponentsLookup.GameSetup); } }

    public void AddGameSetup(Assets.Scripts.GameSetup newValue) {
        var index = GameComponentsLookup.GameSetup;
        var component = (GameSetupComponent)CreateComponent(index, typeof(GameSetupComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameSetup(Assets.Scripts.GameSetup newValue) {
        var index = GameComponentsLookup.GameSetup;
        var component = (GameSetupComponent)CreateComponent(index, typeof(GameSetupComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameSetup() {
        RemoveComponent(GameComponentsLookup.GameSetup);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameSetup;

    public static Entitas.IMatcher<GameEntity> GameSetup {
        get {
            if (_matcherGameSetup == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameSetup);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameSetup = matcher;
            }

            return _matcherGameSetup;
        }
    }
}
