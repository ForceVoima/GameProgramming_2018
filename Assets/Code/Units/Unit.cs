using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
    public abstract class Unit : MonoBehaviour
    {
        public virtual void Init()
        {

        }

        public virtual void Clear()
        {

        }

        // An abstract method has to be defined in a non-abstract child class.
        protected abstract void Update();
    }
}
