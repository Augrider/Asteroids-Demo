using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEntityBuilder
{
    private SpaceObject _spaceObject;
    public ISpaceEntity spaceObject => _spaceObject;


    public SpaceEntityBuilder(SpaceObject spaceObject)
    {
        this._spaceObject = spaceObject;
    }


    public void SetPositionAndDirection(Vector3 position, Vector2 direction)
    {
        _spaceObject.position.SetPosition(position);
        _spaceObject.direction.SetDirection(direction);
    }


    public void SetEntityType(SpaceEntityType entityType) => _spaceObject.entityType = entityType;
    public void SetScoreValue(int value) => _spaceObject.scoreValue = value;

    public void SetMovement(IMovement movement) => _spaceObject.movement = movement;
    public void SetStateComponent(IStateProvider state) => _spaceObject.state = state;

    public void ProvideInteractions(IInteractionsProvider interactions) => _spaceObject.interactions = interactions;


    public void AddBehaviors(params IEntityBehavior[] behaviors)
    {
        var behaviorList = new List<IEntityBehavior>();

        if (spaceObject.behaviors != null)
            behaviorList.AddRange(spaceObject.behaviors);

        behaviorList.AddRange(behaviors);

        _spaceObject.behaviors = behaviorList.ToArray();
    }

    public void AddOnDeathBehaviors(params IOnDeathBehavior[] onDeath)
    {
        var onDeathList = new List<IOnDeathBehavior>();

        if (spaceObject.onDeath != null)
            onDeathList.AddRange(spaceObject.onDeath);

        onDeathList.AddRange(onDeath);

        _spaceObject.onDeath = onDeathList.ToArray();
    }
}
