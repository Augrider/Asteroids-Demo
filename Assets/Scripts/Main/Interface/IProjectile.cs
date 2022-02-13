using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public interface IProjectile
    {
        void Fire(Vector3 direction, Vector2 entitySpeed);
    }
}