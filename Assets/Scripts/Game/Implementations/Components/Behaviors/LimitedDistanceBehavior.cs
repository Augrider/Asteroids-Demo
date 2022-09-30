using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedDistanceBehavior : IEntityBehavior
{
    [SerializeField] private float maxDistance;

    private float currentDistance = 0;


    public LimitedDistanceBehavior(float maxDistance)
    {
        this.maxDistance = maxDistance;
    }


    public void OnSpawned(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies) { }

    public void OnUpdate(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies, float deltaTime)
    {
        currentDistance += self.movement.speed.magnitude * deltaTime;

        if (currentDistance > maxDistance)
            self.state.destroyed = true;
    }
}