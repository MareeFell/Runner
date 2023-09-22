using UnityEngine;

namespace Scenes.Game.Walls
{
    public enum WallType
    {
        Left,
        Right
    }

    public class Wall : MonoBehaviour
    {
        [SerializeField] private WallType wallType;

        public WallType WallType => wallType;
    }
}
