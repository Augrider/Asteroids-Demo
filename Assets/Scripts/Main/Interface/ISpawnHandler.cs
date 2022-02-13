using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEntitySystem.Spawn
{
    public interface ISpawnHandler
    {
        /// <summary>
        /// Spawn entities on field
        /// </summary>
        void SpawnEntities(params GameScriptableObjects.SpaceEntityData[] entities);
    }
}