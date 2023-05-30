using UnityEngine;

namespace Map
{
    public enum NodeType
    {
        MinorEnemy,
        EliteEnemy,
        RestSite,
        Relic,
        HoleInTheWall,
        Boss,
        Mystery
    }
}

namespace Map
{
    [CreateAssetMenu]
    public class NodeBlueprint : ScriptableObject
    {
        public Sprite sprite;
        public NodeType nodeType;
    }
}