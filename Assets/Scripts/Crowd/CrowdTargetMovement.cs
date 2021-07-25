using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolcanicPig.Mobile;
using VolcanicPig.Mobile.Gestures;

namespace Game
{
    public class CrowdTargetMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed; 
        
        private bool _canMove; 
        private GestureController _gestures; 

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
            if (state == GameState.InGame)
            {
                _canMove = true;
            }
            else if (state == GameState.End)
            {
                _canMove = false;
            }
        }

        private void Start() 
        {
            _gestures = GestureController.Instance; 
        }

        private void FixedUpdate() 
        {
            HandleMovement(); 
        }   

        private void HandleMovement()
        {
            if(!_gestures) return; 
            if(!_canMove) return; 

            Vector2 axis = _gestures.Axis;

            if (axis == Vector2.zero)
            {
                return;
            }

            transform.position += new Vector3(axis.x, 0, axis.y) * moveSpeed * Time.deltaTime;
        }
    }
}
