using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankGame.Persistance
{
    [Serializable]
    public class GameData
    {
        public UnitData PlayerData;
        public List<UnitData> EnemyDatas = new List<UnitData>();
    }
}
