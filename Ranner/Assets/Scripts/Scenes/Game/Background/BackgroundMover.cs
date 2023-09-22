using UnityEngine;
using UnityEngine.Serialization;


namespace Scenes.Game.Background
{
    public class BackgroundMover : MonoBehaviour
    {
        [SerializeField]
        private Vector3 velocity = new(-1, 0, 0);

        private Vector3 _startPosition;
        private Timer Timer => FindObjectOfType<Timer>();
        
        private void Start()
        {
            _startPosition = transform.position;
        }

        void Update()
        {
            transform.Translate(velocity * (Timer.Difficult * Time.deltaTime));
        }

        public void Restart()
        {
            transform.position = _startPosition;
        }
    }
}
