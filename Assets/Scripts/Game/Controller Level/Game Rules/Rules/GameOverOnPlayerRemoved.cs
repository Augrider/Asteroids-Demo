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

        return true;
    }
}