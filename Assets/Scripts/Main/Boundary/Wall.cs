using System.Collections;
using System.Collections.Generic;
using GameScriptableObjects.Events;
using UnityEngine;

namespace SpaceEntitySystem
{
    /// <summary>
    /// Wall should destroy any stray object
    /// </summary>
    public class Wall : MonoBehaviour
    {
        [SerializeField] private RemoveEntityEvent removeEntityEvent;


        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.LogWarningFormat("{0}: hit the wall {1}!", other.gameObject, gameObject);

            if (other.gameObject.TryGetComponent<SpaceEntity>(out var entity))
                removeEntityEvent.RaiseEvent(entity);
            else
                Destroy(other.gameObject);
        }
    }
}