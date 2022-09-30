using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityStorage
{
    ISpaceEntity CreateEntity(EntitySpawnData spaceObjectSpawn);
    void RemoveEntity(ISpaceEntity entity);

    ISpaceEntity[] GetSpaceEntities();
}