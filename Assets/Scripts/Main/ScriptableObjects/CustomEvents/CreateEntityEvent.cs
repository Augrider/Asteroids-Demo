using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectsSystem.Events;
using System;

namespace GameScriptableObjects.Events
{
    /// <summary>
    /// Create entity event using SpaceEntityData, position and starting speed
    /// </summary>
    [CreateAssetMenu(menuName = "Game Scriptable Objects/Custom Events/Create Entity Event")]
    public class CreateEntityEvent : GenericArgumentEvent<SpaceEntityData, Vector3, Vector2> { }
}