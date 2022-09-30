using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "Game Data/Space Objects/Base Space Object Data")]
public abstract class BaseSpaceObjectData : SpaceObjectData
{
    [SerializeField] protected float startSpeed;

    [SerializeField] protected PhysicsData physicsData;
    [SerializeField] protected bool loopOnOutOfBounds;

    [SerializeField] protected BaseEntityBehavior[] behaviors;
    [SerializeField] protected BaseOnDeathBehavior[] onDeath;


    protected override void BuildEntityComponents(SpaceEntityBuilder builder, Vector3 position, Vector2 direction)
    {
        var movement = new MovementComponent(physicsData, loopOnOutOfBounds);

        builder.SetMovement(movement);
        builder.SetStateComponent(new StateComponent());

        builder.ProvideInteractions(GetInteractionsComponent());
        builder.AddBehaviors(behaviors);
        builder.AddOnDeathBehaviors(onDeath);
    }


    protected override void PostInit(ISpaceEntity entity)
    {
        entity.movement.speed = startSpeed * entity.direction.forward;
    }


    protected virtual IInteractionsProvider GetInteractionsComponent() => new DefaultInteractions();
}