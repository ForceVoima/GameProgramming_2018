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
    }

}