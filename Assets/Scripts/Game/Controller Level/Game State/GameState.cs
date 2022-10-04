using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameState : MonoBehaviour, IGameState
{
    public bool gameLoopActive { get => _gameLoopActive; set => SetGameLoopActive(value); }
    public event System.Action<bool> gameLoopActiveChanged;

    public Bounds gameAreaBounds { get; private set; }
    public IPhysics physics { get; private set; }

    public int enemiesAmount => GetEnemiesAmount(EntityStorageLocator.service.GetSpaceEntities());

    [SerializeField] private RectTransform gameArea;
    private bool _gameLoopActive;


    public void Initialize(IPhysics physics)
    {
        this.physics = physics;
        this.gameAreaBounds = new Bounds(gameArea.position, gameArea.rect.size);
    }



    private void SetGameLoopActive(bool value)
    {
        _gameLoopActive = value;
        gameLoopActiveChanged?.Invoke(value);
    }


    private int GetEnemiesAmount(ISpaceEntity[] allEntities)
    {
        return allEntities.Count(t => t.entityType == SpaceEntityType.Enemy);
    }
}