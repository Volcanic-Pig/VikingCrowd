using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolcanicPig.Mobile;

namespace Game
{
    public enum PlayerState
    {
        Moving,
        Activity,
        Fighting,
        End
    }

    public class Player : MonoBehaviour
    {
        public static Action<PlayerState> PlayerStateChanged;

        private PlayerState _state;
        public PlayerState State
        { 
            get => _state;
            private set
            {
                _state = value;
                PlayerStateChanged?.Invoke(value);
            }
        }

        private PlayerMovement _movement;
        private PlayerCollisions _collisions;
        private PlayerAnimations _animations;

        public Activity GetActivity => _currentActivity; 
        private Activity _currentActivity; 

        private void OnEnable()
        {
            GameManager.OnGameStateChanged += OnGameStateChanged; 
        }

        private void OnDisable()
        {
            GameManager.OnGameStateChanged -= OnGameStateChanged;
        }

        private void Start() 
        {
            _movement = GetComponent<PlayerMovement>();
            _animations = GetComponent<PlayerAnimations>(); 
            _collisions = GetComponent<PlayerCollisions>();
        }

        private void OnGameStateChanged(GameState state)
        {
            if (state == GameState.InGame)
            {
                if(_movement) _movement.SetMovementEnabled(true);
            }
            else
            {
                if(_movement) _movement.SetMovementEnabled(false);
            }
        }

        public void SetState(PlayerState state)
        {
            State = state;

            switch (state)
            {
                case PlayerState.Moving:
                    _movement.SetMovementEnabled(true);
                    break;
                
                case PlayerState.Activity:
                case PlayerState.End: 
                    _movement.SetMovementEnabled(false);
                    break;
            }
        }

        public void SetActivity(Activity activity)
        {
            _currentActivity = activity; 
        }

        public void StartCurrentActivity()
        {
            if (_currentActivity == null) return; 
            SetState(PlayerState.Activity);
            _currentActivity.StartActivity(this);
        }

        public void DoPunch(Action finishedPunchCallback)
        {
            _animations.Punch(finishedPunchCallback); 
        }
    }
}
