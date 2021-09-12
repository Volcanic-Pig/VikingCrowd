using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        [SerializeField] private AlertObservers observers; 

        private PlayerMovement _movement;

        private int _punchIndex; 
        
        private readonly int _kIsMoving = Animator.StringToHash("IsMoving");
        private readonly int _kRandomPunch = Animator.StringToHash("RandomPunch");  
        private readonly int _kRandomPunchIndex = Animator.StringToHash("RandomPunchIndex");  

        private void Start()
        {
            _movement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (!anim) return;
            anim.SetBool(_kIsMoving, _movement.IsMoving);
        }

        public void Punch(Action finishCallback)
        {
            if (finishCallback != null)
            {
                observers.AddObserver(finishCallback);
            }
            
            anim.SetTrigger(_kRandomPunch);

            if (_punchIndex == 0)
            {
                _punchIndex++;
            }
            else
            {
                _punchIndex = 0;
            }
            
            anim.SetInteger(_kRandomPunchIndex, _punchIndex);
        }
    }
}
