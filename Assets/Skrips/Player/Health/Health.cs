using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _healthRecoveryRate;

    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float HealthRecoveryRate { get => _healthRecoveryRate; set => _healthRecoveryRate = value; }
    public float CurrentHealth
    {
        get => _currentHealth;
        set
        {
            if (value > 0)
                _currentHealth = value;
        }
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
}
