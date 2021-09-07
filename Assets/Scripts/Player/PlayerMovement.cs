using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolcanicPig.Mobile.Gestures;

namespace Game
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool IsMoving => _canMoveForwards || _automatedMovementActive; 
        
        [SerializeField] private float deltaMultiplier, forwardsSpeed, sideSpeed, minYRot, maxYRot;

        private Player _player;
        private Rigidbody _rb;
        private bool _canMoveForwards;
        private bool _canMoveSideways;
        private bool _automatedMovementActive;


        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _player = GetComponent<Player>();
        }

        public void SetMovementEnabled(bool enabled)
        {
            _canMoveForwards = enabled;
            _canMoveSideways = enabled;
        }

        private void Update()
        {
            if (_player.State != PlayerState.Moving)
            {
                _rb.angularVelocity = Vector3.zero;
                return;
            }

            HandleMovement();
        }

        private float _yRot = 0;

        private void HandleMovement()
        {
            if (_automatedMovementActive) return;

            if (_canMoveSideways)
            {
                Vector2 axis = GestureController.Instance.ScaledTouchDelta * deltaMultiplier;
                _yRot += axis.x * sideSpeed * Time.deltaTime;
                _yRot = Mathf.Clamp(_yRot, minYRot, maxYRot);

                transform.rotation = Quaternion.Euler(0, _yRot, 0);
            }
            else
            {
                if(_rb) _rb.angularVelocity = Vector3.zero;
            }

            if (_canMoveForwards)
            {
                transform.position += transform.forward * forwardsSpeed * Time.deltaTime;
            }
        }

        public void AutomatedMovementToPosition(Transform target, Action onComplete)
        {
            _automatedMovementActive = true;
            _yRot = 0;
            StartCoroutine(CoAutomatedMovement(target, onComplete));
        }

        private IEnumerator CoAutomatedMovement(Transform target, Action onComplete)
        {
            while (transform.position != target.position)
            {
                float step = forwardsSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
                transform.LookAt(target);
                yield return null;
            }

            _automatedMovementActive = false;
            if (onComplete != null) onComplete?.Invoke();
        }
    }
}
