
using UnityEngine;

namespace Scenes.Game.Enemies
{
    public class DynamicEnemy: Enemy
    {
        [SerializeField] private AnimationCurve _moveXCurve;
        [SerializeField] private AnimationCurve _moveYCurve;
        [SerializeField] private float _width = 0;
        [SerializeField] private float _height = 0;
        [SerializeField] private float _duration = 0;

        private float position = 0;
        
        protected override Vector3 MoveTo()
        {
            position += Time.deltaTime / _duration;
            
            if (position >= 1)
                position = 0;

            return new Vector3(_width * _moveXCurve.Evaluate(position), _height * _moveYCurve.Evaluate(position), 0);
        }
    }
}