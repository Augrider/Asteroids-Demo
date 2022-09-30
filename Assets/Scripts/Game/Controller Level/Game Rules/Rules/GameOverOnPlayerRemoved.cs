using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameOverOnPlayerRemoved : IGameRule
{
    public bool Check(IGameState gameState, IGameSession gameSession)
    {
        if (gameSession.isPlayerAlive)
            return false;

        SetGameOver(gameState, gameSession);
        return true;
    }



    private void SetGameOver(IGameState gameState, IGameSession gameSession)
    {
        // gameContext.UpdateHighScore(gameState.currentScore, gameState.currentWave);
        // var highestScore = gameContext.GetHighScore(out var highestWave);

        UIPresenterLocator.service.SetGameOver(gameSession.currentScore.score, gameSession.currentScore.wave, gameSession.currentScore.score, gameSession.currentScore.wave);
    }
}
