using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelection : MonoBehaviour
{
    [SerializeField] private GameSetupData gameSetup;


    public void SetDifficulty(GameDifficulty value) => gameSetup.gameDifficulty = value;
}
