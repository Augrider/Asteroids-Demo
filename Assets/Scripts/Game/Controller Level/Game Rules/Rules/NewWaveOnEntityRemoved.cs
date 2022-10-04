using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewWaveOnEntityRemoved : IGameRule
{
    private float waveDelay;
    private bool newWaveInProgress;


    public NewWaveOnEntityRemoved(float waveDelay)
    {
        this.waveDelay = waveDelay;
    }


    public bool Check(IGameState gameState, IGameSession gameSession)
    {
        if (newWaveInProgress)
            return false;

        if (gameState.enemiesAmount > 0)
            return false;

        CoroutinesLocator.service.StartCoroutine(NewWave(gameState, gameSession));
        return true;
    }


    //TODO: Do it elsewhere, GameRules should only check and invoke events
    private IEnumerator NewWave(IGameState gameState, IGameSession gameSession)
    {
        newWaveInProgress = true;

        gameSession.SetWave(gameSession.currentScore.wave + 1);

        yield return new WaitForSeconds(waveDelay);

        foreach (var spawnData in gameSession.gameDifficulty.GetWaveEntities(gameSession.currentScore.wave, gameState.gameAreaBounds))
            EventQueueLocator.service.EnqueueSpaceObjectSpawn(spawnData);

        newWaveInProgress = false;
    }
}
