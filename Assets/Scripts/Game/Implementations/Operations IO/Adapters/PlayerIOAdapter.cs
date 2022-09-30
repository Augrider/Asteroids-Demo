using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIOAdapter : OperationIOComponent, IPlayerOperationInput, IPlayerOperationOutput
{
    public InputData inputData => InputLocator.service.GetInputData();

    public ISpaceEntity playerObject => gameSession.player.playerObject;
    public bool isPlayerAlive => gameSession.isPlayerAlive;

    public WeaponState primary => gameSession.player.primary;
    public WeaponState special => gameSession.player.special;

    public float maxAcceleration => gameSession.player.maxAcceleration;
    public float maxRotationSpeed => gameSession.player.maxRotationSpeed;


    public PlayerIOAdapter(IGameState gameState, IGameSession gameSession) : base(gameState, gameSession)
    {
    }


    public void Fire(WeaponState weapon, Vector3 position, Vector2 direction)
    {
        var projectiles = weapon.GetProjectileSpawns(position, direction);

        weapon.SetCurrentCharges(weapon.chargeState - 1);

        foreach (var projectile in projectiles)
            EventQueueLocator.service.EnqueueSpaceObjectSpawn(projectile);
    }

    public void SetPlayerMovement(Vector2 acceleration, float rotationSpeed)
    {
        playerObject.movement.acceleration = acceleration;
        playerObject.movement.rotationSpeed = rotationSpeed;
    }
}
