using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveDataSystem
{
    public class HighScoreToJSON : IHighScoreSaveHandler
    {
        private string fileName;


        public HighScoreToJSON(string name)
        {
            this.fileName = name + "HighScore.json";
        }


        public (int highScore, int highestWave) Load()
        {
            var dataString = "";

            if (System.IO.File.Exists(GetFilePath(fileName)))
                dataString = System.IO.File.ReadAllText(GetFilePath(fileName));

            if (string.IsNullOrEmpty(dataString))
                return (0, 0);

            var highScoreData = JsonUtility.FromJson<HighScoreData>(dataString);
            return (highScoreData.highScore, highScoreData.highestWave);
        }

        public void Save(int highScore, int highestWave)
        {
            var dataString = JsonUtility.ToJson(new HighScoreData(highScore, highestWave));
            System.IO.File.WriteAllText(GetFilePath(fileName), dataString);
        }



        private string GetFilePath(string fileName)
        {
            return System.IO.Path.Combine(Application.persistentDataPath, fileName);
        }


        [Serializable]
        private struct HighScoreData
        {
            public int highScore;
            public int highestWave;


            public HighScoreData(int highScore, int highestWave)
            {
                this.highScore = highScore;
                this.highestWave = highestWave;
            }
        }
    }
}