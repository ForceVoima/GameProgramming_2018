<<<<<<< HEAD
﻿using System;
=======
using System;
>>>>>>> Kojo/master
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TankGame
{
<<<<<<< HEAD
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
=======
	public class GameManager : MonoBehaviour
	{
		private static GameManager _instance;

		public static GameManager Instance
		{
			get
			{
				if ( _instance == null )
				{
					GameObject gameManagerObject = new GameObject(typeof(GameManager).Name);
					_instance = gameManagerObject.AddComponent< GameManager >();
				}
				return _instance;
			}
		}

		private List<Unit> _enemyUnit = new List< Unit >();
		private Unit _playerUnit = null;

		protected void Awake()
		{
			if ( _instance == null )
			{
				_instance = this;
			}
			else if ( _instance != this )
			{
				Destroy( gameObject );
				return;
			}

			Init();
		}

		private void Init()
		{
			Unit[] allUnits = FindObjectsOfType< Unit >();
			foreach ( Unit unit in allUnits )
			{
				AddUnit(unit);
			}
		}

		public void AddUnit(Unit unit)
		{
			if (unit is EnemyUnit)
			{
				_enemyUnit.Add(unit);
			}
			// Adding a player unit after the initialization really makes no sense because
			// we can have a reference to only one player unit. Be carefull with this
			else if (unit is PlayerUnit)
			{
				_playerUnit = unit;
			}
		}
	}
>>>>>>> Kojo/master
}
