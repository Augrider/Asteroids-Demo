using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsEventListener : MonoBehaviour, IEntityStorage
{
    private Dictionary<ISpaceEntity, GameObject> entities = new Dictionary<ISpaceEntity, GameObject>();


    void Awake()
    {
        EntityStorageLocator.Provide(this);

        EventQueueLocator.service.SpaceObjectCreated += CreateEntityNoReturn;
        EventQueueLocator.service.SpaceObjectRemoved += RemoveEntity;
    }

    void OnDestroy()
    {
        EntityStorageLocator.Provide(null);

        EventQueueLocator.service.SpaceObjectCreated -= CreateEntityNoReturn;
        EventQueueLocator.service.SpaceObjectRemoved -= RemoveEntity;
    }


    public ISpaceEntity[] GetSpaceEntities()
    {
        return entities.Keys.ToArray();
    }


    public ISpaceEntity CreateEntity(EntitySpawnData spaceObjectSpawn)
    {
        (var entityObject, var entity) = spaceObjectSpawn.entitySpawn.GetNewEntity(transform, spaceObjectSpawn.position, spaceObjectSpawn.direction);
        entities.Add(entity, entityObject);

        return entity;
    }


    public void RemoveEntity(ISpaceEntity entity)
    {
        MonoBehaviour.Destroy(entities[entity]);

        entities.Remove(entity);
    }



    private void CreateEntityNoReturn(EntitySpawnData entitySpawn) => CreateEntity(entitySpawn);
}
