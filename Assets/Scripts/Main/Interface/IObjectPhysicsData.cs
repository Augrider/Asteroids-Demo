using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceEntitySystem
{
    public interface IObjectPhysicsData
    {
        float dragValue { get; }
        float dragSpeedMultiplier { get; }
    }
}