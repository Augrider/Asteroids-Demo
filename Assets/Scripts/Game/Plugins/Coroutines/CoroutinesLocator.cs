using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoroutinesLocator
{
    private static ICoroutinesObject nullService { get; } = new NullCoroutinesObject();
    public static ICoroutinesObject service { get; private set; } = nullService;


    public static void Provide(ICoroutinesObject value)
    {
        service = value != null ? value : nullService;
    }
}
