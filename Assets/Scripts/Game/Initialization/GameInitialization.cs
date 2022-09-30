using System;
using System.Collections;
using System.Collections.Generic;
using Developed.ScriptableObjects.Variables;
using UnityEngine;

public class GameInitialization : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameSession gameSession;
    [SerializeField] private GameSetupData gameSetup;

    [SerializeField] private GameLoop gameLoop;
    [SerializeField] private GameRules gameRules;

    [SerializeField] private FloatVariable loadingState;


    void Awake()
    {
        StartCoroutine(LoadGameSession());
    }



    private IEnumerator LoadGameSession()
    {
        InitializeGameState();
        InitializeGameLoop();

        yield return null;
        loadingState.SetValue(0.5f);

        SpawnPlayer();

        yield return null;
        loadingState.SetValue(1);

        gameState.gameLoopActive = true;
        gameRules.StartGame();
    }


    private void InitializeGameState()
    {
        gameState.Initialize(new SpacePhysics());
    }

    private void InitializeGameLoop()
    {
        var initializer = new GameLoopInitialization(gameLoop);
        initializer.Initialize(gameState, gameSession);
    }

    private void SpawnPlayer()
    {
        var initializer = new PlayerInitialization(gameSetup);
        initializer.Initialize(gameState, gameSession);
    }
}
