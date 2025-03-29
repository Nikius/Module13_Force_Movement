using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets.Scripts
{
    public class Game : MonoBehaviour
    {
        private const KeyCode RestartKey = KeyCode.R;
        
        [SerializeField] private int _timeToWin;
        
        [SerializeField] private Ball _ball;
        [SerializeField] private GameObject _coinsContainer;
        
        private List<Coin> _coins;
        
        private float _timeLeft;
        private int _scoreToWin;
        private bool _isGameOver;

        private void Awake()
        {
            _coins = new List<Coin>(_coinsContainer.GetComponentsInChildren<Coin>());
            _scoreToWin = _coins.Count;
        }

        private void Start()
        {
            ResetState();
        }

        private void Update()
        {
            if (Input.GetKeyDown(RestartKey))
                ResetState();
            
            if (_isGameOver)
                return;
            
            _timeLeft -= Time.deltaTime;
            Debug.Log(_timeLeft);

            if (_ball.wallet.CollectedCoins >= _scoreToWin)
                YouWin();
            
            if (_timeLeft <= 0)
                GameOver();
        }

        private void YouWin()
        {
            GameEnd("You win!");
        }

        private void GameOver()
        {
            GameEnd("Game Over");
        }

        private void GameEnd(string message)
        {
            _isGameOver = true;
            
            _ball.gameObject.SetActive(false);
            
            Debug.Log(message);
            
            ShowRestartHint();
        }

        private static void ShowRestartHint()
        {
            Debug.Log($"Press {RestartKey} to Restart");
        }

        private void ResetState()
        {
            ResetGameParams();
            ResetBall();
            ResetCoins();
        }

        private void ResetGameParams()
        {
            _isGameOver = false;
            _timeLeft = _timeToWin;
        }

        private void ResetBall()
        {
            _ball.gameObject.SetActive(true);
            _ball.Reset();
        }

        private void ResetCoins()
        {
            foreach (Coin coin in _coins)
            {
                coin.Reset();
            }
        }
    }
}
