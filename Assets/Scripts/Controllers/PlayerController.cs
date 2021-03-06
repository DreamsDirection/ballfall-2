using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using Controllers.InputControllers;
using Controllers.UI;
using Items.Models;
using TMPro;
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
        private GameState state => GC.GameState;

        public float score;


        private float _timer;
        private float shieldTimer;

        void Start()
        {
            Init();
            if (!_uiGame) _uiGame = UIController.UI.GetUI<UIGame>();
        }

        private void Update()
        {
            if (state == GameState.Play)
            {
                var t = Time.deltaTime;
                _timer -= t;
                shieldTimer -= t;
                if (shieldTimer <= 0) ball.Shield = false;
            }
        }

        public void Init(float positionY = 0, float positionX = 0)
        {
            ball = new Ball()
            {
                AttackInterval = 1,
                BallGravity = GC.BallGravity,
                Health = 3,
                IsDebug = false,
                Shield = false,
                Speed = GC.BallSpeed,
                ShieldTime = 1
            };
            if (!_uiGame) _uiGame = UIController.UI.GetUI<UIGame>();
            _rigidbody2D = TryGetComponent(out Rigidbody2D rb) ? rb : gameObject.AddComponent<Rigidbody2D>();
            if (TryGetComponent(out SpriteRenderer render)) _spriteRenderer = render;
            _rigidbody2D.gravityScale = ball.BallGravity;
            transform.position = new Vector3(positionX, positionY, 0);
             _spriteRenderer.color = Color.white;
        }

        public void Move(Vector2 direct)
        {
            var dir = direct * ball.Speed;
            dir.y = _rigidbody2D.velocity.y;
            _rigidbody2D.velocity = Vector2.Lerp(_rigidbody2D.velocity, dir, 0.25f);
        }


        public void MakeDamage()
        {
            if (_timer <= 0)
            {

                if (!ball.Shield)
                {
                    ball.Health--;
                    if (ball.Health <= 0)
                    {
                        GC.Death();
                    }
                    else
                    {
                        _uiGame.ChangeHealth();
                        _timer = ball.AttackInterval;
                    }
                }
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
                    GC.Death();
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
                    _uiGame.ChangeHealth();
                    Destroy(other.gameObject);
                    if (ball.Health >= 3) ball.Health = 3;
                    break;
                }
                case "Shield":
                {
                    Destroy(other.gameObject);
                    shieldTimer = ball.ShieldTime;
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
