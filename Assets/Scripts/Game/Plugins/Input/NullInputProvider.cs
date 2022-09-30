using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullInputProvider : IInputProvider
{
    public InputData GetInputData() => new InputData();
}