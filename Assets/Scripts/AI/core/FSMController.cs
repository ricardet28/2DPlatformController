using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectAI;

namespace ProjectAI
{
    public class FSMController : MonoBehaviour
    {
        public float detectionRadius;
        public LayerMask collisionMask;
        public int maxCollisions;
        public Color wireColor;

        [SerializeField] State m_current;
        [SerializeField] bool m_isActive;
        [SerializeField] Transform chosenTarget;
        [SerializeField] State defaultState;
        [SerializeField] bool m_isEntityInRange;
        [SerializeField] Material m_material;
        [SerializeField] RaycastHit2D[] m_collisions;

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

        public Material Material
        {
            get
            {
                return m_material;
            }

            set
            {
                m_material = value;
            }
        }

        public RaycastHit2D[] Collisions
        {
            get
            {
                if (m_collisions == null)
                {
                    m_collisions = new RaycastHit2D[maxCollisions];
                }
                return m_collisions;
            }

            set
            {
                m_collisions = value;
            }
        }

        public Transform ChosenTarget
        {
            get
            {
                return chosenTarget;
            }

            set
            {
                chosenTarget = value;
            }
        }

        private void Awake()
        {
            m_isActive = true;
        }

        private void Start()
        {
            m_material = GetComponent<Renderer>().material;
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
                Current = newState;

        }

        // Update is called once per frame
        void Update()
        {
            if (!m_isActive)
                return;
            Current.UpdateState(this);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = wireColor;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }

    }

}
