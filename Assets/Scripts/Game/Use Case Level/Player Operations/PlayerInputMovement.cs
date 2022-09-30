using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovement : IPlayerOperation
{
    public void Run(IPlayerOperationInput input, IPlayerOperationOutput output, float deltaTime)
    {
        var acceleration = input.inputData.acceleration * input.maxAcceleration * input.playerObject.direction.forward;
        var rotationSpeed = input.maxRotationSpeed * input.inputData.rotation;

        output.SetPlayerMovement(acceleration, rotationSpeed);
    }
}