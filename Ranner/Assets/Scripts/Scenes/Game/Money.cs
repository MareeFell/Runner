using System.Collections;
using System.Collections.Generic;
using Scenes.Game;
using UnityEngine;

namespace Scenes.Game
{
    public class Money : MonoBehaviour
    {
        [SerializeField] private int speed = -1;

        private Vector3 _startPosition;
        public float Height => GetComponent<RectTransform>().rect.height;
        private Timer Timer => FindObjectOfType<Timer>();

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            _startPosition.x += speed * Timer.Difficult * Time.deltaTime;
            transform.position = _startPosition;
        }
    }
}
