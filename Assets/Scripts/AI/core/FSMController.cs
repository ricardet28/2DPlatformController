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
        [SerializeField] State remainState;
        [SerializeField] bool m_isEntityInRange;
        [SerializeField] Material m_material;

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

        private void Awake()
        {
            m_isActive = true;
            Material = GetComponent<Material>();
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Transform entity = collision.gameObject.transform;

            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player in");
                m_isEntityInRange = true;
                chosenTarget = entity;
            }


        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Transform entity = collision.gameObject.transform;

            if (collision.gameObject.CompareTag("Player"))
            {
                m_isEntityInRange = false;
                chosenTarget = entity;
            }

        }
    }

}
