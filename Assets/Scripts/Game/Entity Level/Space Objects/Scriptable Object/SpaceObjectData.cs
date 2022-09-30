using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceObjectData : ScriptableObject, IEntitySpawnProvider
{
    [Tooltip("Reference to prefab used as an object in game")]
    [SerializeField] protected GameObject gameObjectPrefab;


    public virtual (GameObject, ISpaceEntity) GetNewEntity(Transform parent, Vector3 position, Vector2 direction)
    {
        var gameObject = GameObject.Instantiate(gameObjectPrefab, parent);

        if (!gameObject.TryGetComponent<SpaceObject>(out var entity))
            throw new System.Exception();

        var builder = new SpaceEntityBuilder(entity);
        BuildEntityComponents(builder, position, direction);

        builder.SetPositionAndDirection(position, direction);
        PostInit(entity);

        return (gameObject, entity);
    }


    protected virtual void PostInit(ISpaceEntity entity) { }

    protected abstract void BuildEntityComponents(SpaceEntityBuilder builder, Vector3 position, Vector2 direction);
}
