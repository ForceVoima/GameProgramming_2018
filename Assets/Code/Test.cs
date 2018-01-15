using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
    public class Test : MonoBehaviour {

        // Use this for initialization
        public void Find()
        {
            Weapon componentToFind = gameObject.GetComponentInHierarchy<Weapon>(true);

            Debug.Log("Found component in: " + componentToFind.transform.gameObject);
        }
    }
}