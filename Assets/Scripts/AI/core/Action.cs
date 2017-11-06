using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectAI
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(FSMController fSMController);

    }
}

