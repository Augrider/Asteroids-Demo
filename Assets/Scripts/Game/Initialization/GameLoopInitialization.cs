using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopInitialization
{
    private GameLoop gameLoop;


    public GameLoopInitialization(GameLoop gameLoop)
    {
        this.gameLoop = gameLoop;
    }


    public void Initialize(GameState gameState, GameSession gameSession)
    {
        gameLoop.entityOperations = GetObjectsOperations(gameState.physics);
        gameLoop.playerOperations = GetPlayerOperations();

        var entityAdapter = new EntityIOAdapter(gameState, gameSession);
        var playerAdapter = new PlayerIOAdapter(gameState, gameSession);

        gameLoop.entityOperationInput = entityAdapter;
        gameLoop.entityOperationOutput = entityAdapter;

        gameLoop.playerOperationInput = playerAdapter;
        gameLoop.playerOperationOutput = playerAdapter;

        gameState.gameLoopActiveChanged += gameLoop.SetGameLoopActive;
    }



    private IPlayerOperation[] GetPlayerOperations()
    {
        return new IPlayerOperation[]
       {
            new PlayerInputMovement(),
            new PlayerInputShoot(),
            new UpdateWeaponStates()
       };
    }

    private IEntityOperation[] GetObjectsOperations(IPhysics physics)
    {
        return new IEntityOperation[]
        {
            new DoBeforeDeathsBehaviors(),
            new DestroyDisabledEntities(),
            new DoBehaviors(),

            new MoveEntities(physics),
            new LoopEntities()
        };
    }
}
