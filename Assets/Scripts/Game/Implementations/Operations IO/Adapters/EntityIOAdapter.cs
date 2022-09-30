using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityIOAdapter : OperationIOComponent, IEntityOperationInput, IEntityOperationOutput
{
    public PlayerState playerState { get => GetPlayerState(); }
    public Bounds bounds => gameState.gameAreaBounds;

    public ISpaceEntity[] entities => EntityStorageLocator.service.GetSpaceEntities();

    private PlayerState previous = new PlayerState();


    public EntityIOAdapter(IGameState gameState, IGameSession gameSession) : base(gameState, gameSession)
    {
    }


    public void CreateEntity(IEntitySpawnProvider entitySpawn, Vector3 position, Vector2 direction)
    {
        var spawn = new EntitySpawnData(entitySpawn, position, direction);

        EventQueueLocator.service.EnqueueSpaceObjectSpawn(spawn);
    }

    public void RemoveEntity(ISpaceEntity entity)
    {
        EventQueueLocator.service.EnqueueSpaceObjectRemoved(entity);
    }


    public void AddScore(int scoreValue)
    {
        gameSession.SetScore(gameSession.currentScore.score + scoreValue);
    }



    public PlayerState GetPlayerState()
    {
        if (gameSession.player.playerObject == null || !gameSession.isPlayerAlive)
            return previous;

        var playerObject = gameSession.player.playerObject;

        previous = new PlayerState()
        {
            position = playerObject.position.value,
            speed = playerObject.movement.speed,
            direction = playerObject.direction.forward
        };

        return previous;
    }
}
