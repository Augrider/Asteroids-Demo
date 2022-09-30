using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Developed.Extentions;

[CreateAssetMenu(menuName = "Game Data/Components/On Death/Spawn Entities")]
public class SpawnOnDeath : BaseOnDeathBehavior
{
    [SerializeField] private SpaceObjectData entityData;
    [SerializeField] private int amount = 4;

    [SerializeField] private bool ignoreDirection;


    public override void Invoke(ISpaceEntity self)
    {
        if (!entityData) throw new System.Exception();

        var entitySpawnData = new EntitySpawnData(entityData, self.position.value, GetDirection(self.direction.forward, 0));

        for (int i = 0; i < amount; i++)
        {
            entitySpawnData.direction = GetDirection(self.direction.forward, i * 360f / amount);

            EventQueueLocator.service.EnqueueSpaceObjectSpawn(entitySpawnData);
        }
    }



    private Vector2 GetDirection(Vector2 entityDirection, float deviation)
    {
        if (ignoreDirection)
            return Vector2.up;

        return MathCustom.Rotate(entityDirection, deviation);
    }
}