using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
    public class TransformMover : MonoBehaviour, IMover
    {
        private float _moveSpeed;
        private float _turnSpeed;

        public void Init(float moveSpeed, float turnSpeed)
        {
            _moveSpeed = moveSpeed;
            _turnSpeed = turnSpeed;
        }

        public void Turn(float amount)
        {
            // Vector3 rotation = Vector3.up * amount * Time.deltaTime * _turnSpeed;
            // transform.Rotate(rotation);

            Vector3 rotation = transform.eulerAngles;
            rotation += Vector3.up * amount * Time.deltaTime * _turnSpeed;

            transform.eulerAngles = rotation;
        }

        public void Move(float amount)
        {
            Vector3 position = transform.position;
            Vector3 movement = transform.forward * amount * _moveSpeed * Time.deltaTime;
            position += movement;
            transform.position = position;

            //transform.Translate(Vector3.forward * amount * _moveSpeed * Time.deltaTime);
        }

        public void Turn(Vector3 targetDirection)
        {
            Vector3 direction = targetDirection - transform.position;
            direction.y = transform.position.y;
            direction.Normalize();
            float turnSpeedRAD = Mathf.Deg2Rad * _turnSpeed * Time.deltaTime;
            Vector3 rotation = Vector3.RotateTowards(transform.forward, direction, turnSpeedRAD, 0.0f);

            transform.rotation = Quaternion.LookRotation(rotation, Vector3.up);
        }

        public void Move(Vector3 direction)
        {
            transform.Translate(direction.normalized * _moveSpeed * Time.deltaTime);
        }
    }

}