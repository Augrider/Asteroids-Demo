using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventQueue
{
    event System.Action<EntitySpawnData> SpaceObjectCreated;

    event System.Action<ISpaceEntity> SpaceObjectRemoved;
    event System.Action SpaceObjectsRemoved;

    void EnqueueSpaceObjectSpawn(EntitySpawnData spawnData);
    void EnqueueSpaceObjectRemoved(ISpaceEntity entity);

    void ResolveEvents();
}