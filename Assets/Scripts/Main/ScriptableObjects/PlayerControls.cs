using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameScriptableObjects
{
    [CreateAssetMenu(menuName = "Game Scriptable Objects/Player Controls")]
    public class PlayerControls : ScriptableObject
    {
        public Vector2 movementInput { get; private set; }
        public bool shootBullet { get; private set; }
        public bool shootLaser { get; private set; }

        private PlayerActions playerActions;


        // Start is called before the first frame update
        void OnEnable()
        {
            InputSubscribe();
        }

        void OnDisable()
        {
            InputUnsubscribe();
        }


        public void OnMovementStarted(InputAction.CallbackContext context)
        {
            movementInput = context.ReadValue<Vector2>();
        }

        public void OnMovementUpdated(InputAction.CallbackContext context)
        {
            movementInput = context.ReadValue<Vector2>();
        }

        public void OnMovementEnded(InputAction.CallbackContext context)
        {
            movementInput = Vector2.zero;
        }


        public void OnShootBulletStarted(InputAction.CallbackContext context)
        {
            shootBullet = true;
        }

        public void OnShootBulletEnded(InputAction.CallbackContext context)
        {
            shootBullet = false;
        }


        public void OnShootLaserStarted(InputAction.CallbackContext context)
        {
            shootLaser = true;
        }

        public void OnShootLaserEnded(InputAction.CallbackContext context)
        {
            shootLaser = false;
        }



        private void InputSubscribe()
        {
            if (playerActions == null)
                playerActions = new PlayerActions();

            playerActions.Spaceship.Movement.started += OnMovementStarted;
            playerActions.Spaceship.Movement.performed += OnMovementUpdated;
            playerActions.Spaceship.Movement.canceled += OnMovementEnded;

            playerActions.Spaceship.ShootBullet.started += OnShootBulletStarted;
            playerActions.Spaceship.ShootBullet.canceled += OnShootBulletEnded;

            playerActions.Spaceship.ShootLaser.started += OnShootLaserStarted;
            playerActions.Spaceship.ShootLaser.canceled += OnShootLaserEnded;

            playerActions.Spaceship.Enable();
        }

        private void InputUnsubscribe()
        {
            playerActions.Spaceship.Movement.started -= OnMovementStarted;
            playerActions.Spaceship.Movement.performed -= OnMovementUpdated;
            playerActions.Spaceship.Movement.canceled -= OnMovementEnded;

            playerActions.Spaceship.ShootBullet.started -= OnShootBulletStarted;
            playerActions.Spaceship.ShootBullet.canceled -= OnShootBulletEnded;

            playerActions.Spaceship.ShootLaser.started -= OnShootLaserStarted;
            playerActions.Spaceship.ShootLaser.canceled -= OnShootLaserEnded;

            playerActions.Spaceship.Disable();
        }
    }
}