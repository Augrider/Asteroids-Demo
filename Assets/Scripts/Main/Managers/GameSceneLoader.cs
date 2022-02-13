using System.Collections;
using System.Collections.Generic;
using SceneManagementSystem;
using UnityEngine;

namespace ManagerSystem
{
    /// <summary>
    /// Main class for handling load/unload of scenes
    /// </summary>
    public class GameSceneLoader : SceneLoader<GameSceneLoader>
    {
        [SerializeField] private GameObject loadingScreen;

        [SerializeField] private ScenePackage mainMenu;
        [SerializeField] private ScenePackage gameScenes;

        [SerializeField] private SceneData gameUI;
        [SerializeField] private SceneData gameOver;


        void Start()
        {
            LoadMainMenu();
        }


        public void LoadMainMenu()
        {
            ShowLoadingScreen();
            UnloadAll();
            LoadFromScenePackage(mainMenu, doAfterLoad: HideLoadingScreen);
        }

        public void LoadGame()
        {
            ShowLoadingScreen();
            UnloadAll();

            LoadFromScenePackage(gameScenes, doAfterLoad: HideLoadingScreen);
        }

        public void OnGameOver()
        {
            StartCoroutine(WaitForShowGameOverScreen());
        }


        protected override void ShowLoadingScreen()
        {
            loadingScreen.SetActive(true);
        }

        protected override void HideLoadingScreen()
        {
            loadingScreen.SetActive(false);
        }



        private IEnumerator WaitForShowGameOverScreen()
        {
            yield return UnloadFromSceneData(gameUI);
            yield return LoadFromSceneData(gameOver);
        }
    }
}