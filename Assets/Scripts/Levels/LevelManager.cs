using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolcanicPig;
using VolcanicPig.Mobile;
using Random = UnityEngine.Random;

namespace Game
{
    public class LevelManager : SingletonBehaviour<LevelManager>
    {
        [SerializeField] private Level[] levels;

        public Level GetCurrentLevel => _currentLevel; 
        private Level _currentLevel;

        private int _lastLevelIndex;

        private void OnEnable()
        {
            GameManager.OnGameStateChanged += GameStateChanged; 
        }

        private void OnDisable()
        {
            GameManager.OnGameStateChanged -= GameStateChanged; 
        }

        private void GameStateChanged(GameState obj)
        {
            if(obj == GameState.Start) SpawnLevel();
        }

        private void Awake()
        {
            SpawnLevel();
        }

        public void SpawnLevel()
        {
            GameManager game = GameManager.Instance;

            if (_currentLevel)
            {
                Destroy(_currentLevel.gameObject);
            }

            if (game.Level >= levels.Length)
            {
                int rand = Random.Range(0, levels.Length);
                _currentLevel = Instantiate(levels[rand], transform);
                _lastLevelIndex = rand;
            }
            else
            {
                _currentLevel = Instantiate(levels[game.Level], transform);
                _lastLevelIndex = game.Level;
            }
        }
    }    
}

