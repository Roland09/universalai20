#if PLAYMAKER && UniversalAI_Integration_PLAYMAKER
using UnityEngine;
using UniversalAI;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("UniversalAI")]
	[Tooltip("Changes The Companion AI's Attack State (Aggressive, Passive)")]
	public class SetCompanionAttackState : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(UniversalAICommandManager))]
		[Tooltip("The AI GameObject That Has The 'AICommandManager'.")]
		public UniversalAICommandManager AICommandManager;
		[Space]
		
		[Tooltip("The New Attack Type For The Companion AI.")]
		public AttackState newAttackState;
		
		public override void OnGUI()
		{
			if(Application.isPlaying)
				return;
			
			if (AICommandManager == null)
			{
				if (Owner.GetComponent<UniversalAICommandManager>() != null)
				{
					AICommandManager = Owner.GetComponent<UniversalAICommandManager>();
				}
			}
		}
		
		// Code that runs on entering the state.
		public override void OnEnter()
		{
			if(AICommandManager == null)
				return;
			
			Execute();
			Finish();
		}
		
		public override void Reset()
		{
			AICommandManager = null;
		}

		public void Execute()
		{
			AICommandManager.CompanionCommands.ChangeAttackState(newAttackState);
		}


	}

}

#endif
