using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using TankGame.AI;
using TankGame.WaypointSystem;

namespace TankGame
{
    public class EnemyUnit : Unit
    {
        [SerializeField] private float _detectPlayerDistance;
        [SerializeField] private float _shootingDistance;
        [SerializeField] private Path _path;
        [SerializeField] private float _wayPointArriveDistance;
        [SerializeField] private PlayerUnit _target;
        [SerializeField] private Direction _direction = Direction.Forward;

        private IList<AIStateBase> _states = new List<AIStateBase>();

        public float DetectPlayerDistance { get { return _detectPlayerDistance; } }
        public float ShootingDistance { get { return _shootingDistance; } }
        public AIStateBase CurrentState { get; private set; }
        public PlayerUnit Target { get { return _target; } set { Target = _target; } }

		public override void Init()
		{
			// Runs the base classes implementation of the Init method. Initializes Mover and 
			// Weapon.
			base.Init();
			// Initializes the state system.
			InitStates();
		}

		private void InitStates()
		{
            PatrolState patrol = new PatrolState(this, _path, _direction, _wayPointArriveDistance);

            // TODO: Implement me!
            _states.Add(patrol);

            CurrentState = _states[0];
            CurrentState.StateActivated();
		}

		protected override void Update()
		{
            // TODO: Remove this.
            if (CurrentState == null)
                return;

			CurrentState.Update();
		}

		public bool PerformTransition( AIStateType targetState )
		{
			if ( !CurrentState.CheckTransition( targetState ) )
			{
				return false;
			}

			bool result = false;

			AIStateBase state = GetStateByType( targetState );
			if ( state != null )
			{
				CurrentState.StateDeactivating();
				CurrentState = state;
				CurrentState.StateActivated();
				result = true;
			}

			return result;
		}

		private AIStateBase GetStateByType( AIStateType stateType )
		{
			// Returns the first object from the list _states which State property's value
			// equals to stateType. If no object is found, returns null.
			return _states.FirstOrDefault( state => state.State == stateType );
			
			// Foreach version of the same thing.
			//foreach ( AIStateBase state in _states )
			//{
			//	if ( state.State == stateType )
			//	{
			//		return state;
			//	}
			//}
			//return null;
		}
	}
}
