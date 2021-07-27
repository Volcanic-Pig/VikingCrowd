using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class PlayerCollisions : MonoBehaviour
	{
		private const string K_Multiplier = "Multiplier"; 
		private void OnTriggerEnter(Collider other) 
		{
			if(other.CompareTag(K_Multiplier))
			{
				Multiplier mult = other.GetComponent<Multiplier>(); 
				mult.Multiply(); 
			}	
		}
	}
}
