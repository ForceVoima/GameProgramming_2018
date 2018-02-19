using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGame
{
    class EnemyHealth : Health
    {
        public EnemyHealth(Unit owner, int startingHealth) : base(owner, startingHealth)
        {
        }

        public override bool TakeDamage(int damage)
        {
            CurrentHealth = 0;
            RaiseUnitDiedEvent();
            return true;
        }
    }
}
