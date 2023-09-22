using System;
using TMPro;
using UnityEngine;

namespace Scenes.Game
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float timeFromLevelUp = 10;
        private float FullTime { get; set; }
        private float _timeFromLevel;
        private TextMeshProUGUI _text;
        public int Points => (int)Math.Floor(FullTime);
        
        
        public float Difficult { get; private set; } = 1;

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            FullTime += Time.deltaTime;
            _timeFromLevel += Time.deltaTime;

            _text.text = $"Очки: {Points}";

            if (_timeFromLevel <= timeFromLevelUp)
                return;
            
            _timeFromLevel = 0;
            Difficult += 1f;
        }
    }
}