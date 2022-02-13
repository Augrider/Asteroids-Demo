using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScriptableObjects
{
    [CreateAssetMenu(menuName = "Game Scriptable Objects/Game Settings/Default")]
    public class DefaultGameSettings : GameSettings
    {
        [SerializeField] protected int initialWaveCost;
        [SerializeField] protected int waveCostRaise;

        [SerializeField] protected int maxSaucersPerWave;

        [SerializeField] protected SpaceEntityData asteroid;
        [SerializeField] protected SpaceEntityData saucer;


        public override SpaceEntityData[] GetWaveEntities(int currentWave)
        {
            var totalCost = initialWaveCost + waveCostRaise * (currentWave - 1);

            var saucersAmount = GetSaucersAmount(totalCost, saucer.scoreCost, maxSaucersPerWave + currentWave / 5);
            totalCost -= saucersAmount * saucer.scoreCost;

            var asteroidsAmount = GetAsteroidsAmount(totalCost, asteroid.scoreCost);

            return GetEntityArray(asteroidsAmount, saucersAmount);
        }



        private int GetSaucersAmount(int totalCost, int scoreCost, int maxSaucersPerWave)
        {
            var maxSaucers = Mathf.Min(maxSaucersPerWave, totalCost / scoreCost);

            return Random.Range(0, maxSaucers + 1);
        }

        private int GetAsteroidsAmount(int totalCost, int scoreCost)
        {
            return totalCost / scoreCost;
        }


        private SpaceEntityData[] GetEntityArray(int asteroidsAmount, int saucersAmount)
        {
            var entityList = new List<SpaceEntityData>();

            for (int i = 0; i < asteroidsAmount; i++)
                entityList.Add(asteroid);

            for (int i = 0; i < saucersAmount; i++)
                entityList.Add(saucer);

            return entityList.ToArray();
        }
    }
}