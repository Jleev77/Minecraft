using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Assets.Scripts
{

    [CreateAssetMenu, Game, Unique]
    public class GameSetup : ScriptableObject
    {
        public GameObject BlankBlock;
        public GameObject Player;
        public Material Brown;
        public Material Green;
        public Material Grey;
    }
}
