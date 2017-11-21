using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectAI;

namespace ProjectAI
{
    [CreateAssetMenu(menuName = "AI/Actions/Idle")]
    public class Idle : Action
    {
        public override void Act(FSMController fSMController)
        {
            fSMController.Material.color = Color.green;
            fSMController.wireColor = Color.green;
        }
    }

}
