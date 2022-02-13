using System.Collections;
using System.Collections.Generic;
using ScriptableObjectsSystem.Variables;
using UnityEngine;

namespace GameScriptableObjects
{
    [CreateAssetMenu(menuName = "Game Scriptable Objects/Game State")]
    public class GameState : ScriptableObject
    {
        public bool isAlive { get; private set; }

        [SerializeField] private IntVariable currentScore;
        [SerializeField] private IntVariable currentWave;

        public int scoreCount => currentScore.runtimeValue;
        public int waveCount => currentWave.runtimeValue;


        void OnEnable()
        {
            Reset();
        }


        public void Reset()
        {
            this.isAlive = false;

            currentScore.SetValue(0);
            currentWave.SetValue(0);
        }


        public void ToggleIsAlive(bool value) => this.isAlive = isAlive;
        public void AddScore(int value) => currentScore.AddValue(value);
        public void AddWave() => currentWave.AddValue(1);
    }
}