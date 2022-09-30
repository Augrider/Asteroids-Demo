using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameSession
{
    GameScoreData currentScore { get; }

    GameDifficulty gameDifficulty { get; }

    Player player { get; }
    bool isPlayerAlive { get; }


    void SetScore(int value);
    void SetWave(int value);

    void ResetScore();
}
