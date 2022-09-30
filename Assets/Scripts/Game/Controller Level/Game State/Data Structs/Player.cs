using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Player
{
    public ISpaceEntity playerObject;

    public WeaponState primary;
    public WeaponState special;

    public float maxAcceleration;
    public float maxRotationSpeed;


    public Player(ISpaceEntity playerObject, WeaponState primary, WeaponState special, float maxAcceleration, float maxRotationSpeed)
    {
        this.playerObject = playerObject;

        this.primary = primary;
        this.special = special;

        this.maxAcceleration = maxAcceleration;
        this.maxRotationSpeed = maxRotationSpeed;
    }
}
