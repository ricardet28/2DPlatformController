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
            Physics2D.CircleCastNonAlloc(fSMController.transform.position, fSMController.detectionRadius, Vector2.zero, fSMController.Collisions);

            for (int i = 0; i < fSMController.Collisions.Length; i++)
            {
                if (fSMController.Collisions[i].transform.CompareTag("Player"))
                {
                    fSMController.ChosenTarget = fSMController.Collisions[i].transform;
                    Debug.Log("Detected");
                    return true;
                }
            }
            return false;
        }
    }

}
