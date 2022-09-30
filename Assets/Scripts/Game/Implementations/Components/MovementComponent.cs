using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : IMovement
{
    public PhysicsData physicsData { get; private set; }
    public bool loopOnOutOfBounds { get; private set; }

    public Vector2 acceleration { get; set; }
    public Vector2 speed { get; set; }

    public float rotationSpeed { get; set; }


    public MovementComponent(PhysicsData physicsData, bool loopOnOutOfBounds)
    {
        this.physicsData = physicsData;
        this.loopOnOutOfBounds = loopOnOutOfBounds;
    }
}
