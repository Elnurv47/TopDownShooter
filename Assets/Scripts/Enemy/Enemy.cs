using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private HealthSystem healthSystem;

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private GameObject deathEffectPrefab;

    public static Action<Vector3> OnDied;

    private void Awake()
    {
        healthSystem = new HealthSystem(maxHealth);
        healthSystem.OnDied += HealthSystem_OnDied;
    }

    public void TakeDamage(int amount)
    {
        healthSystem.DecreaseHealth(amount);
    }

    private void HealthSystem_OnDied()
    {
        Spawner.Spawn(deathEffectPrefab, transform.position, Quaternion.identity);
        OnDied?.Invoke(transform.position);
        Destroy(gameObject);
    }
}
