using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameRule
{
    bool Check(IGameState gameState, IGameSession gameSession);
}
