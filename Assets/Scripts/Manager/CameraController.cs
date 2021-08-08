using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using VolcanicPig;
using VolcanicPig.Mobile;
using VolcanicPig.Utilities;

namespace Game
{
    public class CameraController : SingletonBehaviour<CameraController>
    {
        [SerializeField] private FollowTargetsPosition playerFollower; 
        [SerializeField] private CinemachineVirtualCameraBase inGameCamera;

        private void OnEnable()
        {
            GameManager.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnDisable()
        {
            GameManager.OnGameStateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState state)
        {
            if (state == GameState.Start)
            {
                SetTargets(GameManager.Instance.GetCurrentPlayer.transform);
            }
        }

        public void SetTargets(Transform target)
        {
            playerFollower.SetTarget(target);
        }
    }
}
