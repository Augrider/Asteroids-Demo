using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitialization
{
    [SerializeField] private GameSetupData gameSetup;


    public PlayerInitialization(GameSetupData gameSetup)
    {
        this.gameSetup = gameSetup;
    }


    public void Initialize(GameState gameState, GameSession gameSession)
    {
        var spawn = new EntitySpawnData(gameSetup.playerSetup.playerObject, Vector3.zero, Vector2.up);
        var playerObject = EntityStorageLocator.service.CreateEntity(spawn);

        gameSession.player = GetPlayer(gameSetup.playerSetup, playerObject);
    }



    private Player GetPlayer(PlayerSetupData playerSetup, ISpaceEntity playerObject)
    {
        var primary = new WeaponState(playerSetup.primary);
        var special = new WeaponState(playerSetup.special);

        return new Player(playerObject, primary, special, playerSetup.maxAcceleration, playerSetup.maxRotationSpeed);
    }
}
