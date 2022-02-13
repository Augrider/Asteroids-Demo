using System.Collections;
using System.Collections.Generic;
using ScriptableObjectsSystem.Sets;
using UnityEngine;

namespace GameScriptableObjects
{
    [CreateAssetMenu(menuName = "Game Scriptable Objects/Entity Runtime Set")]
    public class EntityRuntimeSet : RuntimeSet<SpaceEntitySystem.SpaceEntity> { }
}