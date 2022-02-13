using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjectsSystem.Variables;
using UnityEngine;

namespace WeaponSystem
{
    public class Laser : BaseProjectile
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private float defaultLineRange;

        [SerializeField] private FloatVariable liveTime;
        [SerializeField] private FloatVariable laserWidth;


        public override void Fire(Vector3 direction, Vector2 entitySpeed)
        {
            SetLine(direction);

            GameObject[] foundObjects = GetOnLine(direction, defaultLineRange);

            foreach (GameObject gameObject in foundObjects)
                InvokeOnHit(gameObject);

            StartCoroutine(WaitAndDestroy());
        }



        private void SetLine(Vector3 direction)
        {
            lineRenderer.startWidth = laserWidth.runtimeValue * 2;
            lineRenderer.endWidth = laserWidth.runtimeValue * 2;

            lineRenderer.SetPositions(new Vector3[] { transform.position, transform.position + direction * defaultLineRange });
        }


        private GameObject[] GetOnLine(Vector3 direction, float defaultLineRange)
        {
            var raycastHits = Physics2D.CircleCastAll(transform.position, laserWidth.runtimeValue / 2.5f, direction, defaultLineRange);
            return raycastHits.Select(t => t.transform.gameObject).ToArray();
        }


        private IEnumerator WaitAndDestroy()
        {
            yield return new WaitForSeconds(liveTime.runtimeValue);

            Destroy(this.gameObject);
        }
    }
}