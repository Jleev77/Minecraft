using Assets.ECS.Components;
using Entitas.Unity;
using UnityEngine;

public class CollisionList : MonoBehaviour {
 
   void OnCollisionEnter (Collision col) {
      var collisionEntity = (GameEntity) col.gameObject.GetEntityLink().entity;

      if(collisionEntity.gameObjectType.Value != GameObjectType.WorldItem){
         return;
      }
       
      var thisEntity = (GameEntity) gameObject.GetEntityLink().entity;
      var container = thisEntity.container.GameEntities;
      
      for(int i = 0; i < container.Length; i++){
         if(container[i] == null){
            if(collisionEntity.hasStackSize){
               var stackedEntity = Contexts.sharedInstance.game.CreateEntity();
               stackedEntity.AddContainer(new GameEntity[collisionEntity.stackSize.Value]);
               stackedEntity.AddStackSize(collisionEntity.stackSize.Value);
               stackedEntity.AddName(collisionEntity.name.Value);
            }
            container[i] = collisionEntity;
            collisionEntity.ReplaceGameObjectType(GameObjectType.InventoryItem);
            break;
         }
      }
   }
}