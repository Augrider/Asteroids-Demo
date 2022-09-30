using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    bool loopOnOutOfBounds { get; }
    PhysicsData physicsData { get; }

    Vector2 acceleration { get; set; }
    Vector2 speed { get; set; }

    float rotationSpeed { get; set; }
}