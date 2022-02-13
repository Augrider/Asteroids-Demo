using System;
using System.Collections;
using System.Collections.Generic;
using GameScriptableObjects;
using ScriptableObjectsSystem.Variables;
using UnityEngine;

namespace WeaponSystem
{
    /// <summary>
    /// Class for handling weapon state
    /// </summary>
    public class WeaponState
    {
        public WeaponData weaponData { get; private set; }

        private FloatVariable chargeState;

        public float chargeCooldown => weaponData.chargeCooldown;
        public int chargesLeft => weaponData.chargesLeft;
        public float fireCooldown => weaponData.fireCooldown;

        private int maxCharges => weaponData.maxCharges;


        public WeaponState(WeaponData weaponData, FloatVariable chargeState)
        {
            this.weaponData = weaponData;
            this.chargeState = chargeState;
        }


        public void Fire(Vector3 position, Vector3 direction, Vector2 entitySpeed)
        {
            chargeState.SetValue(Mathf.Clamp(chargeState.runtimeValue - 1, 0, maxCharges));
            weaponData.GetProjectile(position).Fire(direction, entitySpeed);
        }


        public void OnUpdate(float time)
        {
            chargeState.SetValue(Mathf.Clamp(chargeState.runtimeValue + time / chargeCooldown, 0, maxCharges));
        }
    }
}