using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OperationIOComponent
{
    protected IGameState gameState;
    protected IGameSession gameSession;


    public OperationIOComponent(IGameState gameState, IGameSession gameSession)
    {
        this.gameState = gameState;
        this.gameSession = gameSession;
    }
}
