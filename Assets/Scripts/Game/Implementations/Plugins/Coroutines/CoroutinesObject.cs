using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinesObject : MonoBehaviour, ICoroutinesObject
{
    void Awake()
    {
        CoroutinesLocator.Provide(this);
    }

    void Destroy()
    {
        CoroutinesLocator.Provide(null);
    }
}
