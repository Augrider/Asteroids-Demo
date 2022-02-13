using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEntitySystem
{
    /// <summary>
    /// Class for handling entity physics
    /// </summary>
    public class SpacePhysics : MonoBehaviour
    {
        public Vector2 position => transform.position;
        public Vector2 forward => rotationTransform.up;

        public float angle => rotationTransform.eulerAngles.z;
        public float speed => _speedVector.magnitude;
        public Vector2 speedVector => _speedVector;

        [SerializeField] private Transform rotationTransform;

        [SerializeField] private Vector2 _speedVector;
        [SerializeField] private Vector2 appliedAcceleration;

        [SerializeField] private float drag;
        [SerializeField] private float dragSpeedMultiplier = 0.1f;

        [SerializeField] private float rotationSpeed = 5;


        void FixedUpdate()
        {
            ApplyRotationSpeed(rotationSpeed);

            ApplyAcceleration(appliedAcceleration - GetDragValue());
            ApplySpeed(_speedVector);
        }


        public void SetPhysicsParameters(IObjectPhysicsData physicsData)
        {
            this.drag = physicsData.dragValue;
            this.dragSpeedMultiplier = physicsData.dragSpeedMultiplier;
        }


        public void SetSpeed(Vector2 speedVector) => this._speedVector = speedVector;
        public void SetAcceleration(Vector2 acceleration) => this.appliedAcceleration = acceleration;

        public void SetRotationSpeed(float rotationSpeed) => this.rotationSpeed = rotationSpeed;
        public void SetDirection(Vector2 direction) => rotationTransform.up = direction.normalized;



        private void ApplyRotationSpeed(float rotationSpeed)
        {
            rotationTransform.Rotate(0, 0, -rotationSpeed * Time.fixedDeltaTime);
        }

        private void ApplySpeed(Vector2 speed)
        {
            transform.position += (Vector3)speed * Time.fixedDeltaTime;
        }

        private void ApplyAcceleration(Vector2 acceleration)
        {
            _speedVector += acceleration * Time.fixedDeltaTime;
        }


        private Vector2 GetDragValue()
        {
            return (drag + dragSpeedMultiplier * speed * drag) * _speedVector.normalized;
        }
    }
}