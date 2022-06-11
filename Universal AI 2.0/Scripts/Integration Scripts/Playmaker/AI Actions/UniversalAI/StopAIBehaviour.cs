#if PLAYMAKER && UniversalAI_Integration_PLAYMAKER
using UnityEngine;
using UniversalAI;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("UniversalAI")]
    [Tooltip("Stop AI Behaviour.")]
    public class StopAIBehaviour : FsmStateAction
    {

        [RequiredField]
        [CheckForComponent(typeof(UniversalAICommandManager))]
        [Tooltip("The AI GameObject That Has The 'AICommandManager'.")]
        public UniversalAICommandManager AICommandManager;

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
            AICommandManager.StopAIBehaviour();
        }


    }

}
#endif