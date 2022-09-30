using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public IEntityOperation[] entityOperations { get; set; }
    public IPlayerOperation[] playerOperations { get; set; }

    public IEntityOperationInput entityOperationInput { get; set; }
    public IEntityOperationOutput entityOperationOutput { get; set; }

    public IPlayerOperationInput playerOperationInput { get; set; }
    public IPlayerOperationOutput playerOperationOutput { get; set; }


    // Update is called once per frame
    void Update()
    {
        if (playerOperationInput.isPlayerAlive)
            UpdatePlayer(Time.deltaTime);

        UpdateEntities(Time.deltaTime);

        EventQueueLocator.service.ResolveEvents();
    }


    public void SetGameLoopActive(bool value) => this.enabled = value;



    private void UpdatePlayer(float deltaTime)
    {
        foreach (IPlayerOperation operation in playerOperations)
            operation.Run(playerOperationInput, playerOperationOutput, deltaTime);
    }

    private void UpdateEntities(float deltaTime)
    {
        foreach (IEntityOperation operation in entityOperations)
            operation.Run(entityOperationInput, entityOperationOutput, deltaTime);
    }
}
