using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Space Objects/Enemy Data")]
public class EnemyData : BaseSpaceObjectData
{
    [SerializeField] private int scoreValue;

    //Starting rotation speed
    [SerializeField] protected float startRotationSpeed;
    [SerializeField] protected float rotationSpeedDeviation;


    protected override void BuildEntityComponents(SpaceEntityBuilder builder, Vector3 position, Vector2 direction)
    {
        base.BuildEntityComponents(builder, position, direction);

        builder.SetScoreValue(scoreValue);
        builder.SetEntityType(SpaceEntityType.Enemy);
    }

    protected override void PostInit(ISpaceEntity entity)
    {
        base.PostInit(entity);

        entity.movement.rotationSpeed = startRotationSpeed + Random.Range(-rotationSpeedDeviation, rotationSpeedDeviation);
    }
}
