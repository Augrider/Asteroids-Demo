using System;
using System.Collections;
using System.Collections.Generic;
using ManagerSystem;
using ScriptableObjectsSystem.Variables;
using TMPro;
using UnityEngine;

namespace UIElements
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private IntVariable currentWave;
        [SerializeField] private IntVariable currentScore;

        [SerializeField] private GameScriptableObjects.GameSettings gameSettings;

        [SerializeField] private TextMeshProUGUI waveCount;
        [SerializeField] private TextMeshProUGUI scoreCount;
        [SerializeField] private TextMeshProUGUI highScore;


        void Start()
        {
            SetText();
        }



        private void SetText()
        {
            waveCount.SetText("Wave " + currentWave.runtimeValue.ToString());
            scoreCount.SetText("Score " + currentScore.runtimeValue.ToString("D6"));

            highScore.SetText("Highscore " + gameSettings.highScore.ToString("D6") + " (" + gameSettings.highestWave.ToString() + ")");
        }
    }
}