using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameSession gameSession;

    [SerializeField] private float waveDelay;
    [SerializeField] private float gameStartDelay;

    private IGameRule newWaveRule;
    private IGameRule gameOverRule;

    public event Action gameStarted;
    public event Action gameOver;


    void Awake()
    {
        newWaveRule = new NewWaveOnEntityRemoved(waveDelay);
        gameOverRule = new GameOverOnPlayerRemoved();

        EventQueueLocator.service.SpaceObjectsRemoved += OnSpaceObjectsRemoved;
    }

    void OnDestroy()
    {
        EventQueueLocator.service.SpaceObjectsRemoved -= OnSpaceObjectsRemoved;
    }


    public void StartGame()
    {
        StartCoroutine(StartGameProcess(gameStartDelay));
    }



    private void OnSpaceObjectsRemoved()
    {
        StartCoroutine(CheckOnDeathRules());
    }

    private IEnumerator CheckOnDeathRules()
    {
        yield return null;

        if (gameOverRule.Check(gameState, gameSession))
        {
            gameOver?.Invoke();
            yield break;
        }

        newWaveRule.Check(gameState, gameSession);
    }


    private IEnumerator StartGameProcess(float delay)
    {
        gameSession.ResetScore();
        yield return new WaitForSeconds(delay);

        newWaveRule.Check(gameState, gameSession);
        gameStarted?.Invoke();
    }
}