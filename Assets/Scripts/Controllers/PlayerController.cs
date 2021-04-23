using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using Controllers.UI;
using Items.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        public Ball ball { get; private set; }

        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;

        GameController GC => GameController.GC;
        private UIGame _uiGame;


        private float _timer;

        void Start()
        {
            ball = new Ball()
            {
                AttackInterval = 1,
                BallGravity = GC.BallGravity,
                Health = 3,
                IsDebug = false,
                Shield = false,
                Speed = GC.BallSpeed
            };
            _uiGame = UIController.UI.GetUI<UIGame>();
            Init();
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
        }

        public void Init()
        {
            ball ??= new Ball()
            {
                AttackInterval = 1,
                BallGravity = GC.BallGravity,
                Health = 3,
                IsDebug = false,
                Shield = false,
                Speed = GC.BallSpeed
            };
            
            _rigidbody2D = TryGetComponent(out Rigidbody2D rb) ? rb : gameObject.AddComponent<Rigidbody2D>();
            if (TryGetComponent(out SpriteRenderer render)) _spriteRenderer = render;
            _rigidbody2D.gravityScale = ball.BallGravity;
            transform.position = Vector2.zero;
        }

        public void Move(Vector2 direct)
        {
            _rigidbody2D.velocity = Vector2.Lerp(_rigidbody2D.velocity, direct, 0.2f);
        }


        public void MakeDamage()
        {
            if (!ball.Shield && _timer <= 0)
            {
                ball.Health--;
                if (ball.Health <= 0)
                {
                    GC.GameOver();
                    UIController.UI.ShowUI<UIGameOver>();
                }
                else
                {
                    _uiGame.ChangeHealth();
                    _timer = ball.AttackInterval;
                }
            }
            else if (ball.Shield)
            {
                ball.Shield = false;
                _spriteRenderer.color = Color.white;
            }
            else
            {
                _timer = ball.AttackInterval;
            }
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("Collision enrer");
            switch (other.collider.tag)
            {
                case "Spike":
                {
                    GC.GameOver();
                    break;
                }
                case "Spike_2":
                {
                    MakeDamage();
                    break;
                }
                case "Saw":
                {
                    MakeDamage();
                    break;
                }
            }

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            switch (other.gameObject.tag)
            {
                case "Spike_2":
                {
                    MakeDamage();
                    break;
                }
                case "Hearth":
                {
                    ball.Health++;
                    UIController.UI.ShowUI<UIGameOver>();
                    Destroy(other.gameObject);
                    if (ball.Health >= 3) ball.Health = 3;
                    break;
                }
                case "Shield":
                {
                    Destroy(other.gameObject);
                    ball.Shield = true;
                    _spriteRenderer.color = Color.green;
                    break;
                }
                case "Time":
                {
                    Destroy(other.gameObject);
                    GC.Camera.ResetSpeed();
                    break;
                }
            }
        }
    }
}
