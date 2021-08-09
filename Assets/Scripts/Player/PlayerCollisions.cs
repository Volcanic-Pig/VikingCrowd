using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class PlayerCollisions : MonoBehaviour
	{
		private const string K_Gate = "Gate";
		private const string K_End = "End"; 
		
		private void OnTriggerEnter(Collider other) 
		{
			if(other.CompareTag(K_Gate))
			{
				
			}	
			else if (other.CompareTag(K_End))
			{
				GameManager.Instance.PlayerReachedEnd();
			}
		}
	}
}
