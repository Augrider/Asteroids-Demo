using System.Collections;
using System.Collections.Generic;
using Developed.ScriptableObjects.Variables;
using UnityEngine;

public class HUDController : MonoBehaviour, IUIPresenter
{
    [SerializeField] private IntVariable currentWave;
    [SerializeField] private IntVariable currentScore;

    [SerializeField] private PlayerStateUI playerStateUI;
    [SerializeField] private WeaponDisplay weaponDisplay;

    [SerializeField] private Canvas hudCanvas;
    [SerializeField] private GameOverScreen gameOverScreen;


    void Awake()
    {
        UIPresenterLocator.Provide(this);
    }

    void OnDestroy()
    {
        UIPresenterLocator.Provide(null);
    }


    public void SetScore(int value)
    {
        currentScore.SetValue(value);
    }

    public void SetWave(int value)
    {
        currentWave.SetValue(value);
    }


    public void UpdatePlayerState(Vector3 position, float angle, float speed)
    {
        playerStateUI.UpdateDisplay(position, angle, speed);
    }

    public void UpdateSpecialWeaponDisplay(float chargeState, int maxCharges, float chargeCooldown)
    {
        weaponDisplay.UpdateDisplay(chargeState, maxCharges, chargeCooldown);
    }


    public void SetGameOver(int score, int wave, int highestScore, int highestWave)
    {
        hudCanvas.enabled = false;

        gameOverScreen.UpdateDisplay(score, wave, highestScore, highestWave);
    }
}