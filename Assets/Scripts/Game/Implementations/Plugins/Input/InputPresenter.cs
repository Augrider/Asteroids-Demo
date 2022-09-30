using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPresenter : MonoBehaviour, IInputProvider
{
    [SerializeField] private InputReceiver inputReceiver;


    void Awake()
    {
        InputLocator.Provide(this);
    }

    void OnDestroy()
    {
        InputLocator.Provide(null);
    }


    public InputData GetInputData()
    {
        return new InputData()
        {
            acceleration = inputReceiver.movementInput.y,
            rotation = -inputReceiver.movementInput.x,

            shootPrimary = inputReceiver.shootPrimary,
            shootSpecial = inputReceiver.shootSpecial
        };
    }
}