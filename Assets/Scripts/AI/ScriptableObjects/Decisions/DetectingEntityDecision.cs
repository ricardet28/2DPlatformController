using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectAI;

namespace ProjectAI
{
    [CreateAssetMenu(menuName = "AI/Decision/Detecting Entity Decision")]
    public class DetectingEntityDecision : Decision
    {
        public override bool Decide(FSMController fSMController)
        {
            return true;
        }
    }

}
