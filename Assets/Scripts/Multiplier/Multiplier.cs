using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class Multiplier : MonoBehaviour
	{
		[SerializeField] private int multiplier; 

		public void Multiply()
		{
			//DO EFFECT
			CrowdController.Instance.MultiplyCrowd(multiplier, transform.position); 
		}
	}
}
