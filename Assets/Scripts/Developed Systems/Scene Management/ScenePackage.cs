using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

namespace Developed.SceneManagement
{
    /// <summary>
    /// Contains scene data collection and handles it's load/unload
    /// </summary>

    [CreateAssetMenu(fileName = "NewScenePackage", menuName = "Scene Package", order = 151)]
    public class ScenePackage : ScriptableObject
    {
        [SerializeField] private SceneReference[] sceneReferences;


        public IEnumerator Load(Action doBeforeLoad = null, Action doAfterLoad = null)
        {
            if (sceneReferences.Length <= 0)
                throw new MissingFieldException("No scenes found in package!");

            doBeforeLoad?.Invoke();
            yield return null;

            foreach (var sceneReference in sceneReferences)
                yield return SceneHandleFunctions.Load(sceneReference);

            doAfterLoad?.Invoke();
            yield return null;
        }

        public IEnumerator Unload(Action doBeforeUnload = null, Action doAfterUnload = null)
        {
            if (sceneReferences.Length <= 0)
                throw new MissingFieldException("No scenes found in package!");

            doBeforeUnload?.Invoke();
            yield return null;

            foreach (var sceneReference in sceneReferences)
                yield return SceneHandleFunctions.Unload(sceneReference);

            doAfterUnload?.Invoke();
            yield return null;
        }
    }
}