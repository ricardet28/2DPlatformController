using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectAI;

namespace ProjectAI
{
    public class FSMController : MonoBehaviour
    {
        [SerializeField] State m_current;
        [SerializeField] Transform m_eyes;
        [SerializeField] bool m_isActive;
        [SerializeField] Transform chosenTarget;
        [SerializeField] State remainState;

        public State Current
        {
            get
            {
                return m_current;
            }

            set
            {
                m_current = value;
            }
        }

        public void InitializeAI(bool init)
        {
            if (!init)
                m_isActive = true;
            else
                m_isActive = false;
        }

        public void TransitionToState(State newState)
        {
            if(newState != remainState)
            {
                //On exit state should be here or in the State class?
                Current = newState;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!m_isActive)
                return;
            Current.UpdateState(this);
        }
    }

}
