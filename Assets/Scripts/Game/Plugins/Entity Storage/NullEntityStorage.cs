using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullEntityStorage : IEntityStorage
{
    public ISpaceEntity CreateEntity(EntitySpawnData spaceObjectSpawn)
    {
        throw new System.NotImplementedException();
    }

    public ISpaceEntity[] GetSpaceEntities()
    {
        throw new System.NotImplementedException();
    }

    public void RemoveEntity(ISpaceEntity entity)
    {
        throw new System.NotImplementedException();
    }
}