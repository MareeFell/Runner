

using UnityEngine;

namespace Scenes.Game.Enemies
{
    public class StaticEnemy: Enemy
    {
        protected override Vector3 MoveTo()
        {
            return Vector3.zero;
        }
    }
}