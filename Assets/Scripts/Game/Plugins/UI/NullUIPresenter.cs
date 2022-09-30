using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullUIPresenter : IUIPresenter
{
    public void UpdatePlayerState(Vector3 position, float angle, float speed) { }
    public void UpdateSpecialWeaponDisplay(float chargeState, int maxCharges, float chargeCooldown) { }

    public void SetWave(int value) { }
    public void SetScore(int value) { }

    public void SetGameOver(int score, int wave, int highestScore, int highestWave) { }
}