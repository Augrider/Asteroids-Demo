using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueue : IEventQueue
{
    private Stack<EntitySpawnData> spaceObjectSpawns = new Stack<EntitySpawnData>();
    private Stack<ISpaceEntity> spaceObjectRemovals = new Stack<ISpaceEntity>();

    public event Action<EntitySpawnData> SpaceObjectCreated;

    public event Action<ISpaceEntity> SpaceObjectRemoved;
    public event Action SpaceObjectsRemoved;


    public void EnqueueSpaceObjectSpawn(EntitySpawnData spawnData)
    {
        spaceObjectSpawns.Push(spawnData);
    }

    public void EnqueueSpaceObjectRemoved(ISpaceEntity spaceObject)
    {
        spaceObjectRemovals.Push(spaceObject);
    }


    public void ResolveEvents()
    {
        ResolveRemoveEvents();
        ResolveSpawnEvents();
    }



    private void ResolveSpawnEvents()
    {
        while (spaceObjectSpawns.Count > 0)
        {
            var entitySpawn = spaceObjectSpawns.Pop();
            SpaceObjectCreated?.Invoke(entitySpawn);
        }
    }

    private void ResolveRemoveEvents()
    {
        var someoneDied = spaceObjectRemovals.Count > 0;

        while (spaceObjectRemovals.Count > 0)
        {
            var spaceObject = spaceObjectRemovals.Pop();
            SpaceObjectRemoved?.Invoke(spaceObject);
        }

        if (someoneDied)
            SpaceObjectsRemoved?.Invoke();
    }
}
