using System;
using System.Collections;
using System.Collections.Generic;
using GameScriptableObjects;
using GameScriptableObjects.Events;
using ScriptableObjectsSystem.Events;
using SpaceEntitySystem;
using SpaceEntitySystem.Spawn;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ManagerSystem
{
    /// <summary>
    /// Main class for handling gameplay loop
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private GameState gameState;

        [SerializeField] private CreateEntityEvent createEntityEvent;
        [SerializeField] private RemoveEntityEvent removeEntityEvent;

        [SerializeField] private EntityRuntimeSet entities;
        [SerializeField] private PlayerEntityData playerEntityData;

        [SerializeField] private RectTransform floor;

        [SerializeField] private float onStartGameWait;
        [SerializeField] private float onStartWaveWait;

        private WaitForSeconds waitForGameStart;
        private WaitForSeconds waitForWaveStart;

        private ISpawnHandler spawnHandler;


        // Start is called before the first frame update
        void Start()
        {
            gameState.Reset();
            entities.Reset();

            waitForGameStart = new WaitForSeconds(onStartGameWait);
            waitForWaveStart = new WaitForSeconds(onStartWaveWait);

            spawnHandler = new EdgesSpawnHandler(createEntityEvent, floor);

            StartCoroutine(GameLoop());
        }


        void OnEnable()
        {
            removeEntityEvent.Subscribe(OnEntityDeath);
        }

        void OnDisable()
        {
            removeEntityEvent.Unsubscribe(OnEntityDeath);
            entities.Reset();
        }



        private void OnEntityDeath(SpaceEntity entity)
        {
            gameState.AddScore(entity.entityData.scoreCost);

            if (entity.entityData.isPlayer)
                OnPlayerDeath();
        }

        private void OnPlayerDeath()
        {
            StopAllCoroutines();

            gameSettings.SaveHighScore(gameState.scoreCount, gameState.waveCount);
            GameSceneLoader.current.OnGameOver();
        }


        private IEnumerator GameLoop()
        {
            yield return GameStart();

            yield return GamePlay();
        }


        private IEnumerator GameStart()
        {
            createEntityEvent.RaiseEvent(playerEntityData, Vector3.zero, Vector2.zero);
            yield return waitForGameStart;
        }

        private IEnumerator GamePlay()
        {
            while (true)
            {
                while (!AllowedToSpawnNewWave())
                    yield return null;

                gameState.AddWave();
                yield return waitForWaveStart;
                Debug.Log("New wave!");

                spawnHandler.SpawnEntities(gameSettings.GetWaveEntities(gameState.waveCount));
            }
        }



        private bool AllowedToSpawnNewWave()
        {
            return entities.count <= 1;
        }
    }
}