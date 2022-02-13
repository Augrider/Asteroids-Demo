using System;
using System.Collections;
using System.Collections.Generic;
using GameScriptableObjects;
using UnityEngine;
using WeaponSystem;

namespace SpaceEntitySystem
{
    /// <summary>
    /// Base class for all game entities
    /// </summary>
    public class SpaceEntity : MonoBehaviour
    {
        public SpacePhysics entityPhysics => physics;
        public Launcher entityLauncher => launcher;
        public SpaceEntityData entityData => _entityData;

        [SerializeField] private SpacePhysics physics;
        [SerializeField] private Launcher launcher;

        [SerializeField] private SpaceEntityData _entityData;

        [SerializeField] private float spawnControlCooldown = 1;
        private bool allowControl = true;

        bool allowToInvert = false;


        // Start is called before the first frame update
        IEnumerator Start()
        {
            _entityData.OnSpawned(this);

            yield return null;
            yield return null;

            allowToInvert = true;

            yield return new WaitForSeconds(spawnControlCooldown);

            ToggleAllowControl(true);
        }

        // Update is called once per frame
        void Update()
        {
            _entityData.OnUpdate(this, allowControl);
        }


        /// <summary>
        /// Function for processing on hit by other ship or boundary
        /// </summary>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<SpaceEntity>(out var entity))
            {
                entityData.OnCollision(this, entity);
                return;
            }

            if (other.gameObject.TryGetComponent<Boundary>(out var boundary))
                InvertPosition(boundary);
        }


        public void Initialize(SpaceEntityData entityData)
        {
            this._entityData = entityData;

            entityData.OnSpawned(this);
        }

        public void ToggleAllowControl(bool value) => this.allowControl = value;

        public void OnHit()
        {
            Debug.LogWarning("Hit!");
            _entityData.OnHit(this);
        }



        private void InvertPosition(Boundary boundary)
        {
            if (allowToInvert)
            {
                boundary.InvertPosition(transform);
                allowToInvert = false;

                return;
            }

            allowToInvert = true;
        }
    }
}