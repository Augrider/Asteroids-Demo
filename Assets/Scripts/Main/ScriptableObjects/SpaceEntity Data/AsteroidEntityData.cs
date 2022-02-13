using System.Collections;
using System.Collections.Generic;
using CommonExtentions;
using SpaceEntitySystem;
using UnityEngine;

namespace GameScriptableObjects
{
    [CreateAssetMenu(menuName = "Game Scriptable Objects/Entities/Asteroid")]
    public class AsteroidEntityData : SpaceEntityData
    {
        [SerializeField] private float maxRotationSpeed = 15;

        [SerializeField] private Events.CreateEntityEvent createEntityEvent;
        [SerializeField] private bool isPiece = false;

        [SerializeField] private AsteroidEntityData pieceData;
        [SerializeField] private int piecesCount = 4;


        public override void OnHit(SpaceEntity entity)
        {
            if (!isPiece)
                SpawnPieces(entity.entityPhysics);

            base.OnHit(entity);
        }

        public override void OnSpawned(SpaceEntity entity)
        {
            entity.entityPhysics.SetRotationSpeed(Random.Range(-maxRotationSpeed, maxRotationSpeed));
        }

        public override void OnUpdate(SpaceEntity entity, bool allowControl) { }



        private void SpawnPieces(SpacePhysics entityPhysics)
        {
            var pieceDirection = entityPhysics.forward;

            for (int i = 0; i < piecesCount; i++)
            {
                createEntityEvent.RaiseEvent(pieceData, entityPhysics.position, pieceDirection * pieceData.startSpeed);

                pieceDirection.Rotate(360f / piecesCount);
            }
        }
    }
}