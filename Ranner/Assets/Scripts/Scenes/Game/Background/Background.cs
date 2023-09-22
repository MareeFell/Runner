using Scenes.Game.Walls;
using UnityEngine;

namespace Scenes.Game.Background
{
    public class Background : MonoBehaviour
    {

        [SerializeField]
        public BackgroundMover target;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.IsHaveType(out LeftWall wall))
            {
                target.Restart();
            }
        }
    }
}