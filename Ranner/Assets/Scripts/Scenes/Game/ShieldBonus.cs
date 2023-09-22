using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Game
{
    [RequireComponent(typeof(Button))]
    public class ShieldBonus: MonoBehaviour
    {
        [SerializeField] private Gamer gamer;
        private Button _button;
        private void Start()
        {
            _button = GetComponent<Button>();
            gamer.OnShieldEnd += () => _button.enabled = false;
        }

        public void BuyShield()
        {
            if (gamer.BuyShield(1))
            {
                _button.enabled = true;
            }
        }
    }
}