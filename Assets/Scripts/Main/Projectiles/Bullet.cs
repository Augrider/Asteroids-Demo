using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectsSystem.Variables;
using SpaceEntitySystem;
using UnityEngine;

namespace WeaponSystem
{
    public class Bullet : BaseProjectile, IProjectile
    {
        [SerializeField] private FloatVariable startingSpeed;
        [SerializeField] private Transform spriteTransform;

        private float speed;
        private Vector2 speedVector;


        public override void Fire(Vector3 direction, Vector2 entitySpeed)
        {
            spriteTransform.up = direction;
            this.speed = startingSpeed.runtimeValue;

            this.speedVector = (Vector2)direction * speed + entitySpeed;
            StartCoroutine(MoveForward(speedVector));
        }

        protected override void OnEntityHit(SpaceEntity entity)
        {
            Destroy(this.gameObject);
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            InvokeOnHit(other.gameObject);
        }



        private IEnumerator MoveForward(Vector2 speedVector)
        {
            while (true)
            {
                transform.Translate(speedVector * Time.deltaTime);
                yield return null;
            }
        }
    }
}