using System;
using UnityEngine;

public class ScoreSystem
{
    private int score = 0;

    public Action<ScoreData> OnScoreChanged;

    public void AddScore(int amount, Vector3 scoreWorldPosition)
    {
        score += amount;
        ScoreData scoreData = new ScoreData(amount, score, scoreWorldPosition);
        OnScoreChanged?.Invoke(scoreData);
    }

    public void DecreaseScore(int amount, Vector3 scoreWorldPosition)
    {
        if (score < 0) score = 0;
        ScoreData scoreData = new ScoreData(amount, score, scoreWorldPosition);
        OnScoreChanged?.Invoke(scoreData);
    }
}

public struct ScoreData
{
    public int ChangeAmount { get; }
    public int UpdatedScore { get; }
    public Vector3 ScoreWorldPosition { get; }

    public ScoreData(int changeAmount, int updatedScore, Vector3 scoreWorldPosition)
    {
        ChangeAmount = changeAmount;
        UpdatedScore = updatedScore;
        ScoreWorldPosition = scoreWorldPosition;
    }
}
