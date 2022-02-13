using System;
using System.Collections;
using System.Collections.Generic;
using SpaceEntitySystem;
using UnityEngine;
using WeaponSystem;

namespace GameScriptableObjects
{
    [CreateAssetMenu(menuName = "Game Scriptable Objects/Entities/Player")]
    public class PlayerEntityData : SpaceEntityData, IObjectPhysicsData
    {
        public override bool isPlayer => true;

        [SerializeField] private PlayerState playerState;
        [SerializeField] private PlayerControls controls;

        public float dragValue => _dragValue;
        [SerializeField] private float _dragValue;

        public float dragSpeedMultiplier => _dragSpeedMultiplier;
        [SerializeField] private float _dragSpeedMultiplier;

        [SerializeField] private float maxAcceleration;

        [SerializeField] private float rotationSpeed = 15;

        [SerializeField] private WeaponData bullet;
        [SerializeField] private WeaponData laser;


        public override void OnSpawned(SpaceEntity entity)
        {
            entity.entityLauncher.Initialize(bullet, laser);
            entity.entityPhysics.SetPhysicsParameters(this);

            Debug.LogFormat("Player spawned!");
        }

        public override void OnUpdate(SpaceEntity entity, bool allowControl)
        {
            playerState.UpdateState(entity);

            if (!allowControl)
                return;

            ControlMovement(entity.entityPhysics);
            FireWeapons(entity.entityLauncher);
        }

        public override void OnHit(SpaceEntity entity)
        {
            Debug.Log("Player hit!");
            playerState.ToggleIsAlive(false);

            base.OnHit(entity);
        }



        private void ControlMovement(SpacePhysics entityPhysics)
        {
            entityPhysics.SetRotationSpeed(rotationSpeed * Math.Sign(controls.movementInput.x));
            entityPhysics.SetAcceleration(entityPhysics.forward * maxAcceleration * Math.Sign(controls.movementInput.y));
        }

        private void FireWeapons(Launcher entityLauncher)
        {
            if (controls.shootLaser)
            {
                entityLauncher.FireWeapon(laser);
                return;
            }

            if (controls.shootBullet)
                entityLauncher.FireWeapon(bullet);
        }
    }
}