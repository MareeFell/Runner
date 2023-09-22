using TMPro;
using UnityEngine;

namespace Scenes.Game
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class MoneyVisualizer : MonoBehaviour
    {
        [SerializeField] private Gamer gamer;

        private TextMeshProUGUI _text;

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            gamer.OnMoneyUpdate += money => _text.text = $"Деньги: {money}";
        }
    }
}