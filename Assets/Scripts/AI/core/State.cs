using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectAI;

namespace ProjectAI
{
    [CreateAssetMenu(menuName = "AI/State")]
    public class State : ScriptableObject
    {
        public Action[] actions;
        public Transition[] transtions;
        public Action[] onEnterActions;
        public Action[] onExitActions;
        public Color stateColor;

        public void UpdateState(FSMController fSMController)
        {
            DoActions(fSMController);
            CheckTranstions(fSMController);
        }

        public void OnExitState(FSMController fSMController)
        {
            if (onExitActions != null)
            {
                for (int i = 0; i < onExitActions.Length; i++)
                {
                    onExitActions[i].Act(fSMController);
                }
            }
        }

        public void OnEnterState(FSMController fSMController)
        {
            if (onEnterActions != null)
            {
                for (int i = 0; i < onEnterActions.Length; i++)
                {
                    onEnterActions[i].Act(fSMController);
                }
            }
        }

        private void DoActions(FSMController fSMController, Action[] actions)
        {
            if(actions != null)
            {
                for (int i = 0; i < actions.Length; i++)
                {
                    actions[i].Act(fSMController);
                }
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

