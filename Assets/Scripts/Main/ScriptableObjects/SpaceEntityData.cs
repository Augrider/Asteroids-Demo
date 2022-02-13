using System;
using System.Collections;
using System.Collections.Generic;
using SpaceEntitySystem;
using UnityEngine;

namespace GameScriptableObjects
{
    public abstract class SpaceEntityData : ScriptableObject
    {
        public int scoreCost;
        public float startSpeed;
        public virtual bool isPlayer => false;

        [SerializeField] private GameObject prefab;
        [SerializeField] private Events.RemoveEntityEvent removeEntityEvent;


        public virtual GameObject SpawnEntity(Transform parent, Vector3 position)
        {
            var newGameObject = GameObject.Instantiate(prefab, parent, false);
            newGameObject.transform.SetPositionAndRotation(position, Quaternion.identity);

            return newGameObject;
        }


        public abstract void OnSpawned(SpaceEntity entity);
        public abstract void OnUpdate(SpaceEntity entity, bool allowControl);

        public virtual void OnHit(SpaceEntity entity)
        {
            removeEntityEvent.RaiseEvent(entity);
        }

        public virtual void OnCollision(SpaceEntity entity, SpaceEntity other)
        {
            if (entity.entityData.isPlayer == other.entityData.isPlayer)
                return;

            Debug.LogWarningFormat("{0}: collision detected!", entity);

            OnHit(entity);
        }
    }
}