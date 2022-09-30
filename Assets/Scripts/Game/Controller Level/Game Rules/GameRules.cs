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

    private IGameRule newWave;
    private IGameRule gameOver;


    void Awake()
    {
        newWave = new NewWaveOnEntityRemoved(waveDelay);
        gameOver = new GameOverOnPlayerRemoved();

        EventQueueLocator.service.SpaceObjectsRemoved += OnSpaceObjectsRemoved;
    }

    void OnDestroy()
    {
        EventQueueLocator.service.SpaceObjectsRemoved -= OnSpaceObjectsRemoved;
    }


    public void StartGame()
    {
        gameSession.ResetScore();
        newWave.Check(gameState, gameSession);
    }


    private void OnSpaceObjectsRemoved()
    {
        if (!gameOver.Check(gameState, gameSession))
            newWave.Check(gameState, gameSession);
    }
}