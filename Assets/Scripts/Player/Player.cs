using UnityEngine;

public class Player : MonoBehaviour
{
    private ScoreSystem scoreSystem;
    public ScoreSystem ScoreSystem { get => scoreSystem; }

    [SerializeField] private PlayerShooting playerShooting;

    private void Awake()
    {
        scoreSystem = new ScoreSystem();
    }
    private void Start()
    {
        playerShooting.OnKilledEnemy += PlayerShooting_OnKilledEnemy;
    }

    private void PlayerShooting_OnKilledEnemy(Vector3 deathPosition)
    {
        scoreSystem.AddScore(5, deathPosition);
    }
}
