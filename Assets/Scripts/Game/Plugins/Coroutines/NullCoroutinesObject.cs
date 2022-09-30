using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullCoroutinesObject : ICoroutinesObject
{
    public Coroutine StartCoroutine(IEnumerator coroutine)
    {
        throw new System.NotImplementedException();
    }
}
