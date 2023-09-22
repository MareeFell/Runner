using Scenes.Game.Enemies;
using UnityEngine;

namespace Scenes.Game.Walls
{
    public class LeftWall: Wall
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.IsHaveType(out Enemy enemy))
            {
                Destroy(enemy.gameObject);
            }
            else if (other.gameObject.IsHaveType(out Money money))
            {
                Destroy(money.gameObject);
            }
        }
    }
}