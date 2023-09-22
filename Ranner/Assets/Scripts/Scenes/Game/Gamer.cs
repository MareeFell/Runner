using System;
using System.Collections;
using Scenes.Game.Enemies;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Scenes.Game
{
    public class Gamer : MonoBehaviour
    {
        [SerializeField] private AnimationCurve jumpCurve;
        [SerializeField] private AnimationCurve slideCurve;
        [SerializeField] private float height = 2;
        [SerializeField] private float time = 2;
        [SerializeField] private float shieldTime = 10;
        private bool IsJumping { get; set; }
        private bool IsSliding { get; set; }
        private bool IsShield { get; set; }

        private int _lifes { get; set; } = 0;
        private bool IsAnyState => IsJumping || IsSliding;

        private int _money = 0;

        public UnityAction<int> OnMoneyUpdate;
        public UnityAction OnShieldEnd;
        public UnityAction<int> OnLifeUpdate;

        void Update()
        {
            if (!IsAnyState)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine(Jump());
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    StartCoroutine(Slide());
                }
            }
        }

        IEnumerator Jump()
        {
            Vector3 startPosition = transform.position;
            IsJumping = true;

            float progress = 0;
            
            while(progress < 1)
            {
                progress += Time.deltaTime / time;
                
                transform.position = startPosition + new Vector3(0,height * jumpCurve.Evaluate(progress),0);
                yield return null;
            }

            IsJumping = false;
        }

        IEnumerator Slide()
        {
            IsSliding = true;

            Vector3 startScale = transform.localScale;

            float progress = 0;
            
            while(progress < 1)
            {
                progress += Time.deltaTime / time;

                transform.localScale = new Vector3(startScale.x, startScale.y * (1 - slideCurve.Evaluate(progress)), startScale.z);
                yield return null;
            }

            IsSliding = false;
        }

        IEnumerator Shield()
        {
            IsShield = true;
            
            float progress = 0;
            
            while(progress < 1)
            {
                progress += Time.deltaTime / shieldTime;
                yield return null;
            }
            
            IsShield = false;
            OnShieldEnd();
        }

        public bool BuyShield(int money)
        {
            
            if (_money < money) return false;
            
            _money -= money;
            OnMoneyUpdate(_money);
            StartCoroutine(Shield());
            return true;
        }

        public void BuyLifes(int money)
        {
            if (_money < money) return;

            _money -= money;
            OnMoneyUpdate(_money);
            _lifes++;
            OnLifeUpdate(_lifes);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.IsHaveType(out Enemy enemy) && !IsShield)
            {
                if (_lifes == 0)
                {
                    Static.Score = FindObjectOfType<Timer>().Points;
                    SceneManager.LoadScene("GameOverScene");
                }
                else
                {
                    _lifes--;
                    OnLifeUpdate(_lifes);
                }
            }

            if (other.gameObject.IsHaveType(out Money money))
            {
                Destroy(money.gameObject);
                _money++;
                OnMoneyUpdate(_money);
            }
        }
    }
}