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

        private Test test;

        protected IMover Mover { get { return _mover; } }

        public Weapon Weapon
        {
            get;
            protected set;
        }

        protected void Awake()
        {
            Init();
        }

        public virtual void Init()
        {
            _mover = gameObject.GetOrAddComponent<TransformMover>();
            _mover.Init(_moveSpeed, _turnSpeed);

            Weapon = GetComponentInChildren<Weapon>();

            if (Weapon != null)
                Weapon.Init(this);

            test = gameObject.GetComponentInHierarchy<Test>(true);

            Debug.Log("test found in: " + test);

            test.Find();
        }

        public virtual void Clear()
        {

        }

        // An abstract method has to be defined in a non-abstract child class.
        protected abstract void Update();
    }
}
