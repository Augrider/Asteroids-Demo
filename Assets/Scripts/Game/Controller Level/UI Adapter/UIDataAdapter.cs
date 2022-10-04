using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDataAdapter : MonoBehaviour
{
    [SerializeField] private GameSession gameSession;
    [SerializeField] private GameState gameState;

    [SerializeField] private GameRules gameRules;


    void Awake()
    {
        gameSession.scoreUpdated += UpdateScore;

        gameState.gameLoopActiveChanged += SetEnabled;
        gameRules.gameStarted += SetEnabled;
        gameRules.gameOver += SetDisabled;

        gameRules.gameOver += SetGameOverUI;
    }

    void LateUpdate()
    {
        UpdatePlayerUI(gameSession.player.playerObject);
        UpdateWeaponUI(gameSession.player.special);
    }

    void OnDestroy()
    {
        gameSession.scoreUpdated -= UpdateScore;

        gameState.gameLoopActiveChanged -= SetEnabled;
        gameRules.gameStarted -= SetEnabled;
        gameRules.gameOver -= SetDisabled;

        gameRules.gameOver -= SetGameOverUI;
    }



    private void UpdateScore(GameScoreData scoreData)
    {
        UIPresenterLocator.service.SetScore(scoreData.score);
        UIPresenterLocator.service.SetWave(scoreData.wave);
    }

    private void UpdatePlayerUI(ISpaceEntity player)
    {
        if (player.state.destroyed)
            return;

        var angle = Vector2.SignedAngle(Vector2.up, player.direction.forward);

        UIPresenterLocator.service.UpdatePlayerState(player.position.value, angle, player.movement.speed.magnitude);
    }

    private void UpdateWeaponUI(WeaponState special)
    {
        UIPresenterLocator.service.UpdateSpecialWeaponDisplay(special.chargeState, special.maxCharges, special.chargeCooldown);
    }

    //TODO: Find out where we should get high score. Probably, in plugin
    private void SetGameOverUI()
    {
        var score = gameSession.currentScore.score;
        var wave = gameSession.currentScore.wave;

        UIPresenterLocator.service.SetGameOver(score, wave, score, wave);
    }


    private void SetEnabled(bool value) => this.enabled = value;
    private void SetEnabled() => SetEnabled(true);
    private void SetDisabled() => SetEnabled(false);
}
