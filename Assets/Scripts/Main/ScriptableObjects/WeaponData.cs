using System.Collections;
using System.Collections.Generic;
using ScriptableObjectsSystem.Variables;
using UnityEngine;
using WeaponSystem;

namespace GameScriptableObjects
{
    [CreateAssetMenu(menuName = "Game Scriptable Objects/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private GameObject projectile;

        public int maxCharges => _maxCharges;
        [SerializeField] private int _maxCharges = 2;

        [SerializeField] private FloatVariable chargeState;
        public int chargesLeft => Mathf.FloorToInt(chargeState.runtimeValue);

        public float chargeCooldown => _chargeCooldown;
        [SerializeField] private float _chargeCooldown = 0.5f;

        public float fireCooldown => _fireCooldown;
        [SerializeField] private float _fireCooldown = 1;


        public virtual IProjectile GetProjectile(Vector3 position)
        {
            var projectileGameObject = GameObject.Instantiate(projectile, position, Quaternion.identity);
            return projectileGameObject.GetComponent<BaseProjectile>();
        }

        public virtual WeaponState GetWeaponState() => new WeaponState(this, chargeState);
    }
}