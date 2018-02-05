using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TankGame.WaypointSystem;
using UnityEngine;

namespace TankGame.AI
{
	public class PatrolState : AIStateBase
	{
		private Path _path;
		private Direction _direction;
		private float _arriveDistance;

		public Waypoint CurrentWaypoint { get; private set; }

		public PatrolState( EnemyUnit owner, Path path, Direction direction, float arriveDistance )
			: base()
		{
			State = AIStateType.Patrol;
			Owner = owner;
			AddTransition( AIStateType.FollowTarget );
			_path = path;
			_direction = direction;
			_arriveDistance = arriveDistance;
		}

		public override void StateActivated()
		{
			base.StateActivated();

            Debug.Log("StateActivated PatrolState");

            Debug.Log(_path.GetClosestWaypoint(Owner.transform.position).Position);

			CurrentWaypoint = _path.GetClosestWaypoint( Owner.transform.position );
		}

		public override void Update()
		{
            // 1. Should we change the state?
            // 1.1 If yes, change state and return.
            if (ChangeState())
                return;

            // 2. Close enough to current waypoint?
            // 2.1 Next waypoint
            CurrentWaypoint = GetWaypoint();

            // 3. Move toward the current waypoint
            Owner.Mover.Move(Owner.transform.forward);

            // 4. Rotate toward the current waypoint
            HeadTowardWaypoint();
        }

        private bool ChangeState()
        {
            int mask = LayerMask.GetMask("Player)");

            Collider[] players = Physics.OverlapSphere(Owner.transform.position, Owner.DetectPlayerDistance, mask);

            if (players.Length > 0)
            {
                PlayerUnit player = players[0].gameObject.GetComponentInHierarchy<PlayerUnit>();
                Owner.Target = player;
                Owner.PerformTransition(AIStateType.FollowTarget);
                return true;
            }
            else
                return false;
        }

        private Waypoint GetWaypoint()
        {
            Waypoint result = CurrentWaypoint;
            Vector3 toWayPoint = Owner.transform.position - CurrentWaypoint.Position;
            float distance = Vector3.SqrMagnitude(toWayPoint);

            if (distance < Owner.DetectPlayerDistance)
            {
                result = _path.GetNextWaypoint(CurrentWaypoint, ref _direction);
            }

            return result;
        }

        private void HeadTowardWaypoint()
        {
            Vector3 toWayPoint = Owner.transform.position - CurrentWaypoint.Position;
            Owner.Mover.Turn(toWayPoint);
        }
	}
}
