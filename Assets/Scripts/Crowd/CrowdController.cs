using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolcanicPig;
using VolcanicPig.Mobile;

namespace Game
{
	public class CrowdController : SingletonBehaviour<CrowdController>
	{
		private List<CrowdFollower> crowd = new List<CrowdFollower>(); 
		public int CrowdSize => crowd.Count; 

		public void MultiplyCrowd(int multiplier, Vector3 pos)
		{
			int amountToAdd = 1;
			
			if(CrowdSize > 0)
			{
				amountToAdd = (CrowdSize * multiplier) - CrowdSize; 
			}
			else
			{
				amountToAdd = multiplier; 
			}

			for(int i = 0; i < amountToAdd; i++)
			{
				CrowdFollower follower = ObjectPool.Instance.SpawnFromPool("Crowd", null, pos) as CrowdFollower; 
				crowd.Add(follower); 
			}
		}
	}
}
