using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICoroutinesObject
{
    Coroutine StartCoroutine(IEnumerator coroutine);
}
