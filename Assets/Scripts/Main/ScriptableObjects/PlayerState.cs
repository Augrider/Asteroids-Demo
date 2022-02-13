using System.Collections;
using System.Collections.Generic;
using ScriptableObjectsSystem.Variables;
using UnityEngine;

namespace GameScriptableObjects
{
    [CreateAssetMenu(menuName = "Game Scriptable Objects/Player State")]
    public class PlayerState : ScriptableObject
    {
        public Vector2Variable position;
        public FloatVariable angle;
        public FloatVariable speed;

        public bool isAlive { get; private set; } = true;


        public void UpdateState(SpaceEntitySystem.SpaceEntity entity)
        {
            position.SetValue(entity.entityPhysics.position);
            angle.SetValue(entity.entityPhysics.angle);
            speed.SetValue(entity.entityPhysics.speed);
        }

        public void ToggleIsAlive(bool value) => isAlive = value;
    }
}