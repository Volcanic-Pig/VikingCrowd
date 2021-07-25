using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace Game
{
	public class CrowdFollower : MonoBehaviour
	{
		[SerializeField] private Transform target; 

		[Header("Obstacle Raycast")]
		[SerializeField] private float rayLength; 
		
		[SerializeField] private LayerMask _layer; 
		private NavMeshAgent _agent;  

		private void Start() 
		{
			_agent = GetComponent<NavMeshAgent>();  	
		}

		private void Update() 
		{
			if(!target) return; 

			if(IsBlocked())
			{
				_agent.isStopped = true; 
			}
			else
			{
				_agent.isStopped = false; 
				_agent.SetDestination(target.position);  	
			}
		}

		private bool IsBlocked()
		{
			RaycastHit hit; 
			Vector3 direction = (target.position - transform.position).normalized; 

			Debug.DrawLine(transform.position, transform.position + (direction *  rayLength), Color.blue);

			if(Physics.Raycast(transform.position, direction, out hit, rayLength,  _layer)) return true; 
			
			return false; 
		}
	}
}
