using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopEntities : IEntityOperation
{
    //TODO: Set from outside
    private float loopMultiplier = 0.96f;


    public void Run(IEntityOperationInput input, IEntityOperationOutput output, float deltaTime)
    {
        foreach (var entity in input.entities)
        {
            if (!entity.movement.loopOnOutOfBounds)
                continue;

            if (input.bounds.Contains(entity.position.value))
                continue;

            Vector2 multiplier = GetAxisMultipliers(entity.position.value, entity.movement.speed, input.bounds);

            entity.position.SetPosition(entity.position.value * multiplier);
        }
    }



    private Vector2 GetAxisMultipliers(Vector3 position, Vector2 speed, Bounds bounds)
    {
        var invertX = bounds.extents.x < Mathf.Abs(position.x);
        var invertY = bounds.extents.y < Mathf.Abs(position.y);

        var isDirectionOutX = Mathf.Sign(position.x * speed.x);
        var isDirectionOutY = Mathf.Sign(position.y * speed.y);

        return new Vector2(invertX ? -isDirectionOutX * loopMultiplier : 1, invertY ? -isDirectionOutY * loopMultiplier : 1);
    }
}