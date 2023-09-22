using System.Collections.Generic;
using Scenes.Game.Enemies;
using Scenes.Game.Walls;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scenes.Game
{
    [RequireComponent(typeof(Wall), typeof(RectTransform))]
    public class GeneratorEnemies : MonoBehaviour
    {
        [SerializeField] private Money money;
        [SerializeField] private List<Enemy> enemies;
        [SerializeField] private float speed;
        [SerializeField] private float moneySpeed;
        
        private float _time;
        private float _moneyTime;
        
        private RectTransform _rectTransform;
        private float HalfHeight => _rectTransform.rect.height / 2;
        private Timer Timer => FindObjectOfType<Timer>();
        
        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        void Update()
        {
            _moneyTime += Time.deltaTime;
            _time += Time.deltaTime;


            if (_time > speed - Timer.Difficult)
            {
                _time = 0;
                CreateEnemy();
            }

            if (_moneyTime > moneySpeed - Timer.Difficult)
            {
                _moneyTime = 0;
                CreateMoney();
            }
        }

        private void CreateMoney()
        {
            Instantiate(money, transform.parent);
            money.transform.localPosition = transform.localPosition +
                                            new Vector3(0, Random.Range(-HalfHeight, HalfHeight - money.Height));
        }


        private void CreateEnemy()
        {
            Enemy target = enemies[Random.Range(0, enemies.Count)];

            Enemy enemy = Instantiate(target, transform.parent);
            
            enemy.transform.localPosition = transform.localPosition +
                                      new Vector3(0, Random.Range(-HalfHeight, HalfHeight - enemy.Height));
        }
    }
}