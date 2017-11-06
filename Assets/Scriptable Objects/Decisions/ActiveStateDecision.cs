using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectAI;

namespace ProjectAI
{
    public class ActiveStateDecision : Decision
    {
        public override bool Decide(FSMController fSMController)
        {
            //decide which state gonna be active
            Debug.Log("Im Deciding");
            return true;
        }
    }

}
