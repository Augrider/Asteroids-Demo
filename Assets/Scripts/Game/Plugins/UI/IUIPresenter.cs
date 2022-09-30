using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIPresenter
{
    void UpdatePlayerState(Vector3 position, float angle, float speed);
    void UpdateSpecialWeaponDisplay(float chargeState, int maxCharges, float chargeCooldown);

    void SetWave(int value);
    void SetScore(int value);

    void SetGameOver(int score, int wave, int highestScore, int highestWave);
}