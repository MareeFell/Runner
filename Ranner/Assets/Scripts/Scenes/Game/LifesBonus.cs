using UnityEngine;

namespace Scenes.Game
{
    public class LifesBonus: MonoBehaviour
    {
        [SerializeField] private Gamer gamer;

        public void BuyLife()
        {
            gamer.BuyLifes(1);
        }
    }
}