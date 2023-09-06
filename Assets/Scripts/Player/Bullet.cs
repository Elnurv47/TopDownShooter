using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float AUTO_DESTROY_TIME = 5f;
    [SerializeField] private int damageAmount = 50;
    [SerializeField] private GameObject hitEffectPrefab;

    private void Awake()
    {
        Destroy(gameObject, AUTO_DESTROY_TIME);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damageAmount);
            Spawner.Spawn(hitEffectPrefab, collider.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
