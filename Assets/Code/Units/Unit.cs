using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
    public abstract class Unit : MonoBehaviour
    {
        private IMover _mover;

        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _turnSpeed = 50f;

        protected IMover Mover { get { return _mover; } }

        protected void Awake()
        {
            Init();
        }

        public virtual void Init()
        {
            _mover = GetComponent<IMover>();

            if (_mover == null)
                Debug.LogError("IMover is missing in " + gameObject);
            else
                _mover.Init(_moveSpeed, _turnSpeed);
        }

        public virtual void Clear()
        {

        }

        // An abstract method has to be defined in a non-abstract child class.
        protected abstract void Update();
    }
}
