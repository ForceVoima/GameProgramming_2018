using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
    public class PlayerUnit : EnemyUnit
    {
        Vector3 _input = Vector3.zero;

        protected override void Update()
        {
            ReadInput();

            Mover.Turn(_input.x);
            Mover.Move(_input.z);

            bool shoot = Input.GetButton("Fire1");

            if (shoot)
            {
                Weapon.Shoot();
            }
        }

        private Vector3 ReadInput()
        {
            _input.x = Input.GetAxis("Horizontal");
            _input.z = Input.GetAxis("Vertical");

            return _input;
        }
    }
}
