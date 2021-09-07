using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class PlayerCollisions : MonoBehaviour
	{
		private Player _player;
		private PlayerMovement _movement;
		private Gate _currentGate;  
		
		private const string K_Gate = "Gate";
		private const string K_End = "End";

		private void Start()
		{
			_player = GetComponent<Player>(); 
			_movement = GetComponent<PlayerMovement>();
		}

		private void OnTriggerEnter(Collider other) 
		{
			if(other.CompareTag(K_Gate))
			{
				Gate gate = other.GetComponent<Gate>();
				_player.SetState(PlayerState.Activity);  
				_currentGate = gate; 
				_movement.AutomatedMovementToPosition(gate.animStartPos, OnMoveToGateComplete);
			}	
			else if (other.CompareTag(K_End))
			{
				GameManager.Instance.PlayerReachedEnd();
			}
		}

		private void OnMoveToGateComplete()
		{
			_currentGate.StartActiviy(_player);
		}
	}
}
