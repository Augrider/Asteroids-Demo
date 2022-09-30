using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDataAdapter : MonoBehaviour
{
    [SerializeField] private GameSession gameSession;
    [SerializeField] private GameState gameState;


    void Awake()
    {
        gameSession.scoreUpdated += UpdateScore;
        gameState.gameLoopActiveChanged += SetEnabled;
    }

    void LateUpdate()
    {
        UpdateScore(gameSession.currentScore);
        UpdatePlayerUI(gameSession.player.playerObject);
        UpdateWeaponUI(gameSession.player.special);
    }

    void OnDestroy()
    {
        gameSession.scoreUpdated -= UpdateScore;
        gameState.gameLoopActiveChanged -= SetEnabled;
    }



    private void UpdateScore(GameScoreData scoreData)
    {
        UIPresenterLocator.service.SetScore(scoreData.score);
        UIPresenterLocator.service.SetWave(scoreData.wave);
    }

    private void UpdatePlayerUI(ISpaceEntity player)
    {
        var angle = Vector2.SignedAngle(Vector2.up, player.direction.forward);

        UIPresenterLocator.service.UpdatePlayerState(player.position.value, angle, player.movement.speed.magnitude);
    }

    private void UpdateWeaponUI(WeaponState special)
    {
        UIPresenterLocator.service.UpdateSpecialWeaponDisplay(special.chargeState, special.maxCharges, special.chargeCooldown);
    }


    private void SetEnabled(bool value) => this.enabled = value;
}
