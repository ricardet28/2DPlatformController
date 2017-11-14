using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectAI;

namespace ProjectAI
{
    public class FSMController : MonoBehaviour
    {
        [SerializeField] State m_current;
        [SerializeField] bool m_isActive;
        [SerializeField] Transform chosenTarget;
        [SerializeField] State defaultState;
        [SerializeField] bool m_isEntityInRange;

        public Animator animator;
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

        public bool IsEntityInRange
        {
            get
            {
                return m_isEntityInRange;
            }
        }

        private void Awake()
        {
            m_isActive = true;
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
           
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
            if(newState != defaultState)
            {
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
