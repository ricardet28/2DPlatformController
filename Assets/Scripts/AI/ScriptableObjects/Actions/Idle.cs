using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectAI;

namespace ProjectAI
{
    public class Idle : Action
    {
        public override void Act(FSMController fSMController)
        {
            Debug.Log("Im Idleling");
        }
    }

}
