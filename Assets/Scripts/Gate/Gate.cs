using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine; 
using VolcanicPig.Mobile.Gestures;

namespace Game
{
    public class Gate : MonoBehaviour
    {
        public UnityEvent OnActivityPerformed;
        public UnityEvent OnActivityLastPerform; 
        
        protected Player Player;
        
        public Transform animStartPos;
        public float activityHealth;
        public CinemachineVirtualCameraBase activityCamera; 

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
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                PerformActivity();
            }
        }
#endif

        private void OnTouchDown(Vector2 pos)
        {
            PerformActivity();
        } 

        public virtual void PerformActivity()
        {
            if (!_started) return;
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
