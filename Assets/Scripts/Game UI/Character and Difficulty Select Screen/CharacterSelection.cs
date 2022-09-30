using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameSetupData gameSetup;


    public void SetPlayerShip(PlayerSetupData value) => gameSetup.playerSetup = value;
}
