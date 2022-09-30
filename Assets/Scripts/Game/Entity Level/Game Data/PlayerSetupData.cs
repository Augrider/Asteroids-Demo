using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/General/Player Setup Data")]
public class PlayerSetupData : ScriptableObject
{
    public IEntitySpawnProvider playerObject => _playerObject;

    public float maxAcceleration => _maxAcceleration;
    public float maxRotationSpeed => _maxRotationSpeed;

    public WeaponData primary => _primary;
    public WeaponData special => _special;

    [SerializeField] private SpaceObjectData _playerObject;

    [SerializeField] private float _maxAcceleration;
    [SerializeField] private float _maxRotationSpeed;

    [SerializeField] private WeaponData _primary;
    [SerializeField] private WeaponData _special;
}
