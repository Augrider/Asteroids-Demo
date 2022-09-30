using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Space Objects/Player Data")]
public class PlayerData : BaseSpaceObjectData
{
    protected override void BuildEntityComponents(SpaceEntityBuilder builder, Vector3 position, Vector2 direction)
    {
        base.BuildEntityComponents(builder, position, direction);

        builder.SetEntityType(SpaceEntityType.Player);
    }
}