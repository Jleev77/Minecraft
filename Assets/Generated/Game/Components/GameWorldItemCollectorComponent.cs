//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Assets.ECS.Components.WorldItemCollectorComponent worldItemCollectorComponent = new Assets.ECS.Components.WorldItemCollectorComponent();

    public bool isWorldItemCollector {
        get { return HasComponent(GameComponentsLookup.WorldItemCollector); }
        set {
            if (value != isWorldItemCollector) {
                var index = GameComponentsLookup.WorldItemCollector;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : worldItemCollectorComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherWorldItemCollector;

    public static Entitas.IMatcher<GameEntity> WorldItemCollector {
        get {
            if (_matcherWorldItemCollector == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.WorldItemCollector);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWorldItemCollector = matcher;
            }

            return _matcherWorldItemCollector;
        }
    }
}
