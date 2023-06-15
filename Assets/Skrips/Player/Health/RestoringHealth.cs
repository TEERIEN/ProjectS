using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoringHealth : Health
{
    [SerializeField] private float _recoveryTime;

    private float timer;

    public float RecoveryTime { get => _recoveryTime; set => _recoveryTime = value; }

    private void FixedUpdate()
    {
        RegenerateHealth();
    }

    private void RegenerateHealth()
    {
        if (CurrentHealth < MaxHealth)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= RecoveryTime)
            {
                CurrentHealth += HealthRecoveryRate;
                CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);
            }
        }
        else
        {
            timer = 0f;
        }
    }
}
