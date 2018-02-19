using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TankGame
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject gameManagerObject = new GameObject(typeof(GameManager).Name);
                    _instance = gameManagerObject.GetOrAddComponent<GameManager>();
                }

                return _instance;
            }
        }

        private PlayerUnit _playerUnit;
        private List<EnemyUnit> _enemyUnit = new List<EnemyUnit>();

        protected void Awake()
        {
            // 
            if (_instance != null)
            {
                _instance = this;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Init();
        }

        private void Init()
        {
            Unit[] allUnits = FindObjectsOfType<Unit>();

            foreach (Unit unit in allUnits)
            {
                if (unit is EnemyUnit)
                {
                    EnemyUnit enemy = unit as EnemyUnit;
                    _enemyUnit.Add(enemy);
                }
                else if (unit is PlayerUnit)
                {
                    PlayerUnit player = unit as PlayerUnit;
                    _playerUnit = player;
                }
            }
        }
    }
}
