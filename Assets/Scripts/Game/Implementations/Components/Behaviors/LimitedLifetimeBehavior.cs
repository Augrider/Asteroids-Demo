using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedLifetimeBehavior : IEntityBehavior
{
    [SerializeField] private float lifetime;
    private float currentLifetime = 0;


    public LimitedLifetimeBehavior(float lifetime)
    {
        this.lifetime = lifetime;
    }


    public void OnSpawned(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies) { }

    public void OnUpdate(ISpaceEntity self, PlayerState playerData, ISpaceEntity[] enemies, float deltaTime)
    {
        currentLifetime += deltaTime;

        if (currentLifetime > lifetime)
            self.state.destroyed = true;
    }
}
