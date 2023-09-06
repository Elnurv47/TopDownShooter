using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform playerTransform;

    [SerializeField] private float speed;

    private void Awake()
    {
        playerTransform = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        transform.position = 
            Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }
}
