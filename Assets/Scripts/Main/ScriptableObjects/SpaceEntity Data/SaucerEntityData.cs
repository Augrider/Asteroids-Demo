using System;
using System.Collections;
using System.Collections.Generic;
using SpaceEntitySystem;
using UnityEngine;

namespace GameScriptableObjects
{
    [CreateAssetMenu(menuName = "Game Scriptable Objects/Entities/Asteroid")]
    public class SaucerEntityData : SpaceEntityData
    {
        [SerializeField] private PlayerState playerState;
        [SerializeField] private float speedComponentMultiplier = 0.5f;


        public override void OnSpawned(SpaceEntity entity) { }

        public override void OnUpdate(SpaceEntity entity, bool allowControl)
        {
            if (allowControl)
                AccelerateTowardsPlayer(entity.entityPhysics, playerState.position.runtimeValue);
        }



        private void AccelerateTowardsPlayer(SpacePhysics physics, Vector2 playerPosition)
        {
            var vector = (playerPosition - physics.position);
            physics.SetSpeed((startSpeed + speedComponentMultiplier * vector.magnitude) * vector.normalized);
        }
    }
}