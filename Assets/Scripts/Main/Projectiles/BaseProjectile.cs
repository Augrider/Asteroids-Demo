using System;
using System.Collections;
using System.Collections.Generic;
using SpaceEntitySystem;
using UnityEngine;

namespace WeaponSystem
{
    public abstract class BaseProjectile : MonoBehaviour, IProjectile
    {
        [SerializeField] private bool hitPlayer = false;


        protected void InvokeOnHit(GameObject gameObject)
        {
            if (!gameObject.TryGetComponent<SpaceEntity>(out var entity))
                return;

            if (IsPlayer(entity) && !hitPlayer)
                return;

            entity.OnHit();
            OnEntityHit(entity);
        }



        private bool IsPlayer(SpaceEntity entity)
        {
            return entity.entityData.isPlayer;
        }


        public abstract void Fire(Vector3 direction, Vector2 entitySpeed);
        public virtual void OnBoundaryHit() => Destroy(this.gameObject);
        protected virtual void OnEntityHit(SpaceEntity entity) { }
    }
}