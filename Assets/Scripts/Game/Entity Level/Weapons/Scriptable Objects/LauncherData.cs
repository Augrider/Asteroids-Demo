using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LauncherData : ScriptableObject
{
    public abstract EntitySpawnData[] GetProjectilesSpawnData(IEntitySpawnProvider projectile, Vector3 position, Vector2 direction);
}
