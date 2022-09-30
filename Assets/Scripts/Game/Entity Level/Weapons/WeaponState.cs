using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for handling weapon state
/// </summary>
public class WeaponState
{
    private IEntitySpawnProvider projectileSpawn;
    private LauncherOffsetData[] launchers;

    public float chargeState { get; private set; }

    public float chargeCooldown { get; private set; }
    public float fireCooldown { get; private set; }

    public int maxCharges { get; private set; }


    public WeaponState(WeaponData weaponData)
    {
        this.projectileSpawn = weaponData.projectileProvider;
        this.launchers = weaponData.launchers;

        this.chargeCooldown = weaponData.oneChargeCooldown;
        this.fireCooldown = weaponData.fireCooldown;

        this.maxCharges = weaponData.maxCharges;
    }


    public void SetCurrentCharges(float value)
    {
        chargeState = Mathf.Clamp(value, 0, maxCharges);
    }

    public EntitySpawnData[] GetProjectileSpawns(Vector3 position, Vector2 direction)
    {
        var result = new List<EntitySpawnData>();

        foreach (var launcher in launchers)
            result.AddRange(GetProjectilesSpawnData(launcher, position, direction));

        return result.ToArray();
    }



    private EntitySpawnData[] GetProjectilesSpawnData(LauncherOffsetData launcherData, Vector3 objectPosition, Vector2 objectDirection)
    {
        var launcherPosition = GetLauncherPosition(objectPosition, objectDirection, launcherData.offsetPosition);
        var launcherDirection = GetLauncherDirection(objectDirection, launcherData.offsetDirection);

        return launcherData.launcherData.GetProjectilesSpawnData(projectileSpawn, launcherPosition, launcherDirection);
    }


    private Vector2 GetLauncherPosition(Vector2 objectPosition, Vector2 objectDirection, Vector2 launcherOffset)
    {
        var resultLinear = objectDirection * launcherOffset.y;
        var resultPerpendicular = -Vector2.Perpendicular(objectDirection) * launcherOffset.x;

        var result = resultLinear + resultPerpendicular;

        return objectPosition + result;
    }

    private Vector2 GetLauncherDirection(Vector2 objectDirection, Vector2 launcherDirection)
    {
        if (launcherDirection == Vector2.zero)
            return objectDirection;

        var originNormal = launcherDirection.normalized;

        var resultLinear = objectDirection * originNormal.y;
        var resultPerpendicular = -Vector2.Perpendicular(objectDirection) * originNormal.x;

        return resultLinear + resultPerpendicular;
    }
}