using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectAI;

namespace ProjectAI
{
    [CreateAssetMenu(menuName = "AI/State")]
    public class State : ScriptableObject
    {
        Action[] actions;
        Transition[] transtions;

        public void UpdateState(FSMController fSMController)
        {
            DoActions(fSMController);
            CheckTranstions(fSMController);
        }

        public void DoActions(FSMController fSMController)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Act(fSMController);
            }
        }

        private void CheckTranstions(FSMController fSMController)
        {
            for (int i = 0; i < transtions.Length; i++)
            {
                bool decision = transtions[i].decision.Decide(fSMController);

                if (decision)
                    fSMController.TransitionToState(transtions[i].trueState);
                else
                    fSMController.TransitionToState(transtions[i].falseState);
            }
        }

    }
}

