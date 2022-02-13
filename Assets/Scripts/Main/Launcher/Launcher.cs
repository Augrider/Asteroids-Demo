using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameScriptableObjects;
using UnityEngine;

namespace WeaponSystem
{
    /// <summary>
    /// Class for handling projectiles spawn and launch
    /// </summary>
    public class Launcher : MonoBehaviour
    {
        private List<WeaponState> weaponStates = new List<WeaponState>();
        private Vector3 direction => transform.up;
        [SerializeField] private SpaceEntitySystem.SpacePhysics physics;

        private float launchCooldown = 0;


        public void Initialize(params WeaponData[] weapons)
        {
            foreach (WeaponData weaponData in weapons)
                weaponStates.Add(weaponData.GetWeaponState());
        }


        // Update is called once per frame
        void Update()
        {
            launchCooldown = Mathf.Clamp(launchCooldown - Time.deltaTime, 0, launchCooldown);
            UpdateStates(Time.deltaTime);
        }


        public void FireWeapon(WeaponData weaponData)
        {
            var weaponState = weaponStates.FirstOrDefault(t => t.weaponData == weaponData);

            if (!ReadyToFire(weaponState))
                return;

            weaponState.Fire(transform.position, direction, physics.speedVector);
            launchCooldown = weaponState.fireCooldown;
        }



        private bool ReadyToFire(WeaponState weaponState)
        {
            return weaponState != null && launchCooldown <= 0 && weaponState.chargesLeft > 0;
        }


        private void UpdateStates(float deltaTime)
        {
            foreach (WeaponState weaponData in weaponStates)
                weaponData.OnUpdate(deltaTime);
        }
    }
}