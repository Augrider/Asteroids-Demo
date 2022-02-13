using System;
using System.Collections;
using System.Collections.Generic;
using SaveDataSystem;
using UnityEngine;

namespace GameScriptableObjects
{
    /// <summary>
    /// Base class for storing high score and getting entities for waves
    /// </summary>
    public abstract class GameSettings : ScriptableObject
    {
        public int highScore { get; private set; }
        public int highestWave { get; private set; }


        void OnEnable()
        {
            var highScoreSaver = new HighScoreToJSON(this.name);
            (highScore, highestWave) = highScoreSaver.Load();
        }


        public void SaveHighScore(int highScore, int highestWave)
        {
            if (this.highScore < highScore)
                this.highScore = highScore;

            if (this.highestWave < highestWave)
                this.highestWave = highestWave;

            var highScoreSaver = new HighScoreToJSON(this.name);
            highScoreSaver.Save(highScore, highestWave);
        }


        public abstract SpaceEntityData[] GetWaveEntities(int currentWave);
    }
}