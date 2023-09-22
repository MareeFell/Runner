using UnityEngine;


namespace Scenes.Game.Enemies
{
    [RequireComponent(typeof(RectTransform), typeof(BoxCollider2D))]
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField]
        private int speed = -1;
        
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
            Vector3 currentTranslate = _startPosition + MoveTo();
            transform.position = currentTranslate;
        }

        protected abstract Vector3 MoveTo();
    }
}
