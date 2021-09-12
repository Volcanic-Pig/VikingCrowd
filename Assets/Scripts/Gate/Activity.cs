using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine; 
using VolcanicPig.Mobile.Gestures;

namespace Game
{
    public class Activity : MonoBehaviour
    {
        public UnityEvent OnActivityPerformed;
        public UnityEvent OnActivityLastPerform; 
        
        protected Player Player;
        
        public Transform animStartPos;
        public float activityHealth;
        public CinemachineVirtualCameraBase activityCamera;

        private bool _canPerform;  

        protected bool _started;

        private void OnEnable()
        {
            GestureController.OnTouchDown += OnTouchDown; 
        }

        private void OnDisable()
        {
            GestureController.OnTouchDown -= OnTouchDown; 
        }

        public void StartActivity(Player player)
        {
            activityCamera.m_Priority = 10; 
            Player = player;
            _started = true;
            _canPerform = true;
        }

        private void OnTouchDown(Vector2 pos)
        {
            if (!_canPerform) return; 
            PerformActivity();
        } 

        public virtual void PerformActivity()
        {
            if (!_started) return;
            _canPerform = false; 
        }

        public virtual void ActivityPerformed()
        {
            activityHealth -= 1;
            if (activityHealth <= 0)
            {
                OnActivityLastPerform?.Invoke();
                EndActivity();
            }
            else
            {
                OnActivityPerformed?.Invoke();
                _canPerform = true;
            }
        }

        public void EndActivity()
        {
            activityCamera.m_Priority = -1; 
            _started = false; 
            Player.SetState(PlayerState.Moving);
        }

    }
}
