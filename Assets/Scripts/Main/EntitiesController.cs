using System.Collections;
using System.Collections.Generic;
using GameScriptableObjects;
using GameScriptableObjects.Events;
using UnityEngine;

namespace SpaceEntitySystem
{
    /// <summary>
    /// Component used for creating, storing and removing entities
    /// </summary>
    public class EntitiesController : MonoBehaviour
    {
        [SerializeField] private CreateEntityEvent createEntityEvent;
        [SerializeField] private RemoveEntityEvent removeEntityEvent;

        [SerializeField] private EntityRuntimeSet entities;


        void OnEnable()
        {
            createEntityEvent.Subscribe(CreateEntity);
            removeEntityEvent.Subscribe(RemoveEntity);
        }

        void OnDisable()
        {
            createEntityEvent.Unsubscribe(CreateEntity);
            removeEntityEvent.Unsubscribe(RemoveEntity);
        }



        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="message">Container for entity data, position and speed</param>
        private void CreateEntity(SpaceEntityData entityData, Vector3 position, Vector2 speed)
        {
            var newEntityObject = entityData.SpawnEntity(transform, position);
            var entity = newEntityObject.GetComponent<SpaceEntity>();

            entity.Initialize(entityData);
            entities.Add(entity);

            entity.entityPhysics.SetSpeed(speed);
            entity.entityPhysics.SetDirection(speed);

            Debug.LogFormat("Created {0}", entity);
        }

        /// <summary>
        /// Remove entity from game
        /// </summary>
        /// <param name="entity">Entity to remove</param>
        private void RemoveEntity(SpaceEntity entity)
        {
            Debug.LogFormat("Destroyed {0}", entity);

            entities.Remove(entity);
            Destroy(entity.gameObject);
        }
    }
}