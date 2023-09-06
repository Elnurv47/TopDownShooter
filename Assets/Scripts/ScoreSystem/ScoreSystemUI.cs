using TMPro;
using UnityEngine;

public class ScoreSystemUI : MonoBehaviour
{
    private ScoreSystem scoreSystem;
    [SerializeField] private Player player;
    [SerializeField] private TextMesh floatingTextPrefab;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreSystem = player.ScoreSystem;
        scoreSystem.OnScoreChanged += ScoreSystem_OnScoreChanged;
    }

    private void ScoreSystem_OnScoreChanged(ScoreData scoreData)
    {
        TextMesh spawnedFLoatingText =
            Spawner.Spawn(floatingTextPrefab, scoreData.ScoreWorldPosition + new Vector3(1, 1), Quaternion.identity);
        spawnedFLoatingText.text = $"+ {scoreData.ChangeAmount}";

        scoreText.text = scoreData.UpdatedScore.ToString();
    }
}
