using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private Animator anim;

        private PlayerMovement _movement;
        
        private int _kIsMoving = Animator.StringToHash("IsMoving");

        private void Start()
        {
            _movement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (!anim) return;
            anim.SetBool(_kIsMoving, _movement.IsMoving);
        }
    }
}
