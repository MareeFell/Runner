using System;
using TMPro;
using UnityEngine;

namespace Scenes.Game
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LifeVisualizer: MonoBehaviour
    {
        private TextMeshProUGUI _text;

        [SerializeField] private Gamer gamer;

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            gamer.OnLifeUpdate = life => _text.text = $"Жизни: {life}";
        }
    }
}