using System.Collections;
using System.Collections.Generic;
using GameScriptableObjects;
using GameScriptableObjects.Events;
using UnityEngine;

namespace SpaceEntitySystem.Spawn
{
    public class EdgesSpawnHandler : ISpawnHandler
    {
        private CreateEntityEvent createEntityEvent;
        private Bounds bounds;


        public EdgesSpawnHandler(CreateEntityEvent createEntityEvent, Bounds bounds)
        {
            this.createEntityEvent = createEntityEvent;
            this.bounds = bounds;
        }

        public EdgesSpawnHandler(CreateEntityEvent createEntityEvent, RectTransform rectTransform)
        {
            this.createEntityEvent = createEntityEvent;
            this.bounds = new Bounds(rectTransform.position, rectTransform.rect.size);
        }


        public void SpawnEntities(params SpaceEntityData[] entities)
        {
            foreach (SpaceEntityData entityData in entities)
            {
                var spawnPoint = GetRandomPoint();
                createEntityEvent.RaiseEvent(entityData, spawnPoint, GetRandomDirection(spawnPoint) * entityData.startSpeed);
            }
        }



        private Vector3 GetRandomPoint()
        {
            var circlePoint = Random.insideUnitCircle.normalized * bounds.size.magnitude;
            return bounds.ClosestPoint(circlePoint) * 0.9f;
        }

        private Vector3 GetRandomDirection(Vector3 spawnPoint)
        {
            var circlePoint = (Vector3)Random.insideUnitCircle.normalized * bounds.extents.magnitude * 0.1f;
            return (circlePoint - spawnPoint).normalized;
        }
    }
}