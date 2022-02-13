using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEntitySystem
{
    /// <summary>
    /// Boundary should loop entities and call specific behaviour on projectiles
    /// </summary>
    public class Boundary : MonoBehaviour
    {
        [SerializeField] private bool invertHorizontal;
        [SerializeField] private bool invertVertical;

        [SerializeField] private float positionMultiplier = 0.95f;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<WeaponSystem.BaseProjectile>(out var projectile))
                projectile.OnBoundaryHit();
        }


        public void InvertPosition(Transform other)
        {
            var invertX = invertHorizontal ? -1 : 1;
            var invertY = invertVertical ? -1 : 1;

            other.position = new Vector2(other.transform.position.x * invertX, other.transform.position.y * invertY) * positionMultiplier;
        }
    }
}