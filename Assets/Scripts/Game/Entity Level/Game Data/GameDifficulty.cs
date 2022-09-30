using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameDifficulty : ScriptableObject
{
    public abstract EntitySpawnData[] GetWaveEntities(int currentWave, Bounds bounds);
}