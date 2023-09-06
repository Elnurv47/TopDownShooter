using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private const string FIRING_BUTTON = "Fire1";
    [SerializeField] private float bulletForce;
    [SerializeField] private GameObject bulletPrefab;

    public Action<Vector3> OnKilledEnemy;

    private void Start()
    {
        Enemy.OnDied += Enemy_OnDied;
    }

    private void Update()
    {
        if (Input.GetButtonDown(FIRING_BUTTON))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject spawnedBullet = Spawner.Spawn(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRigidbody = spawnedBullet.GetComponent<Rigidbody2D>();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 forceDirection = (mousePosition - transform.position).normalized;
        bulletRigidbody.AddForce(forceDirection * bulletForce, ForceMode2D.Impulse);
    }

    private void Enemy_OnDied(Vector3 deathPosition)
    {
        OnKilledEnemy?.Invoke(deathPosition);
    }
}
