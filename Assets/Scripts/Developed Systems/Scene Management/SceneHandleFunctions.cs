using System;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Developed.SceneManagement
{
    internal static class SceneHandleFunctions
    {
        public static string GetSceneName(SceneReference sceneReference)
        {
            var SceneName = sceneReference.ScenePath.Split('/').Last();
            var extension = SceneName.Split('.').Last();

            string SceneNameWithOutExtension = SceneName.Substring(0, SceneName.Length - extension.Length - 1);
            return SceneNameWithOutExtension;
        }


        public static IEnumerator Load(SceneReference sceneReference)
        {
            if (sceneReference == null)
                throw new ArgumentNullException("Scene reference is empty!");

            var operation = SceneManager.LoadSceneAsync(GetSceneName(sceneReference), LoadSceneMode.Additive);
            while (!operation.isDone)
                yield return null;
        }

        public static IEnumerator Unload(SceneReference sceneReference)
        {
            if (sceneReference == null)
                throw new ArgumentNullException("Scene reference is empty!");

            var scene = SceneManager.GetSceneByPath(sceneReference.ScenePath);

            var operation = SceneManager.UnloadSceneAsync(scene);
            while (!operation.isDone)
                yield return null;
        }
    }
}