using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameState
{
    bool gameLoopActive { get; set; }

    IPhysics physics { get; }
    Bounds gameAreaBounds { get; }

    //Store reference to player entity
    //Get entity data in adapter class?
    //Where to store and maintain adapter?
}
