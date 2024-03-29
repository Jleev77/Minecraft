//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Assets.ECS.Components.StackSizeComponent stackSize { get { return (Assets.ECS.Components.StackSizeComponent)GetComponent(GameComponentsLookup.StackSize); } }
    public bool hasStackSize { get { return HasComponent(GameComponentsLookup.StackSize); } }

    public void AddStackSize(int newValue) {
        var index = GameComponentsLookup.StackSize;
        var component = (Assets.ECS.Components.StackSizeComponent)CreateComponent(index, typeof(Assets.ECS.Components.StackSizeComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceStackSize(int newValue) {
        var index = GameComponentsLookup.StackSize;
        var component = (Assets.ECS.Components.StackSizeComponent)CreateComponent(index, typeof(Assets.ECS.Components.StackSizeComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveStackSize() {
        RemoveComponent(GameComponentsLookup.StackSize);
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

    static Entitas.IMatcher<GameEntity> _matcherStackSize;

    public static Entitas.IMatcher<GameEntity> StackSize {
        get {
            if (_matcherStackSize == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StackSize);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStackSize = matcher;
            }

            return _matcherStackSize;
        }
    }
}
