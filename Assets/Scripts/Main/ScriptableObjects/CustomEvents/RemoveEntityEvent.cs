using System.Collections;
using System.Collections.Generic;
using ScriptableObjectsSystem.Events;
using UnityEngine;

namespace GameScriptableObjects.Events
{
    /// <summary>
    /// Remove entity event using SpaceEntity reference
    /// </summary>
    [CreateAssetMenu(menuName = "Game Scriptable Objects/Custom Events/Remove Entity Event")]
    public class RemoveEntityEvent : GenericArgumentEvent<SpaceEntitySystem.SpaceEntity> { }
}