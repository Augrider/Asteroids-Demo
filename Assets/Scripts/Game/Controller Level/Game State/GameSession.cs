using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour, IGameSession
{
    public GameScoreData currentScore => _currentScore;
    public event System.Action<GameScoreData> scoreUpdated;

    public Player player { get; set; }
    public bool isPlayerAlive => !player.playerObject.state.destroyed;

    public GameDifficulty gameDifficulty { get => gameSetup.gameDifficulty; }

    [SerializeField] private GameSetupData gameSetup;
    private GameScoreData _currentScore = new GameScoreData();


    public void SetWave(int value)
    {
        _currentScore.wave = value;
        scoreUpdated?.Invoke(currentScore);
    }

    public void SetScore(int value)
    {
        _currentScore.score = value;
        scoreUpdated?.Invoke(currentScore);
    }


    public void ResetScore()
    {
        _currentScore.score = 0;
        _currentScore.wave = 0;

        scoreUpdated?.Invoke(currentScore);
    }
}
