using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformComponent : MonoBehaviour, IPositionProvider, IDirectionProvider
{
    public Vector2 value => transform.position;
    public Vector2 forward => transform.up;


    public void SetPosition(Vector2 value) => transform.position = value;
    public void SetDirection(Vector2 value) => transform.up = value;
}
