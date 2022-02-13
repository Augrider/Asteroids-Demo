using System.Collections;
using System.Collections.Generic;
using ManagerSystem;
using UnityEngine;

public class ButtonMethods : MonoBehaviour
{
    public void StartGame() => GameSceneLoader.current.LoadGame();
    public void Restart() => GameSceneLoader.current.LoadGame();
    public void ToMainMenu() => GameSceneLoader.current.LoadMainMenu();
    public void Quit() => Application.Quit();
}
