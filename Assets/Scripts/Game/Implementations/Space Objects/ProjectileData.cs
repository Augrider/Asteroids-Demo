using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Space Objects/Projectile Data")]
public class ProjectileData : BaseSpaceObjectData
{
    [SerializeField] protected bool pierce;

    [SerializeField] protected float lifetime;
    [SerializeField] protected float maxDistance;

    protected override IInteractionsProvider GetInteractionsComponent() => new ProjectileInteractions(pierce);


    protected override void BuildEntityComponents(SpaceEntityBuilder builder, Vector3 position, Vector2 direction)
    {
        base.BuildEntityComponents(builder, position, direction);

        builder.SetEntityType(SpaceEntityType.Projectile);

        if (lifetime > 0)
            builder.AddBehaviors(new LimitedLifetimeBehavior(lifetime));

        if (maxDistance > 0)
            builder.AddBehaviors(new LimitedDistanceBehavior(maxDistance));
    }
}