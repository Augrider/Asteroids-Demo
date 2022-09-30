using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all game entities
/// </summary>
public class SpaceObject : MonoBehaviour, ISpaceEntity
{
    public SpaceEntityType entityType { get; internal set; } = SpaceEntityType.Enemy;
    public int scoreValue { get; internal set; }

    public IPositionProvider position => transformComponent;
    public IDirectionProvider direction => transformComponent;

    public IMovement movement { get; internal set; }
    public IStateProvider state { get; internal set; }
    public IInteractionsProvider interactions { get; internal set; }

    public IOnDeathBehavior[] onDeath { get; internal set; }
    public IEntityBehavior[] behaviors { get; internal set; }

    [SerializeField] private TransformComponent transformComponent;
}