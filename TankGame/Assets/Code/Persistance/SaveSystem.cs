using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGame.Persistance
{
    public class SaveSystem
    {
        private IPersistance _persistance;

        public SaveSystem(IPersistance persistance)
        {
            _persistance = persistance;
        }
    }
}
