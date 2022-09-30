using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/General/Game Setup")]
public class GameSetupData : ScriptableObject
{
    public PlayerSetupData playerSetup;
    public GameDifficulty gameDifficulty;
}
