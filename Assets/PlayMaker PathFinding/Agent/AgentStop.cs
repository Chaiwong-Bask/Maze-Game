// (c) Copyright HutongGames, LLC 2010-2014. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.NavMeshAgent)]
	[Tooltip("Stop movement of the agent along the current path. \n" +
		"NOTE: The Game Object must have a NavMeshAgent component attached.")]
	public class AgentStop : FsmStateAction
	{
		[RequiredField]
		[Tooltip("The Game Object to work with. NOTE: The Game Object must have a NavMeshAgent component attached.")]
		[CheckForComponent(typeof(UnityEngine.AI.NavMeshAgent))]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("If true, the agent position and orientation is no longer controlled by the NavMeshAgent.")]
		public FsmBool stopUpdates;
		
		private UnityEngine.AI.NavMeshAgent _agent;
		
		private void _getAgent()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null) 
			{
				return;
			}
			
			_agent =  go.GetComponent<UnityEngine.AI.NavMeshAgent>();
		}	
		
		public override void Reset()
		{
			gameObject = null;
			stopUpdates = null;
		}

		public override void OnEnter()
		{
			_getAgent();
			
			DoStop();

			Finish();		
		}
		
		void DoStop()
		{
			if (_agent == null) 
			{
				return;
			}
			
			_agent.Stop(stopUpdates.Value);
		}

	}
}