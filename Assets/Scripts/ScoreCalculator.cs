using UnityEngine;
using TMPro;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private BallMerger _ballMerger;
    [SerializeField] private TextMeshProUGUI _scoreText; 

    private int[] _scoreTable = { 0, 1, 3, 6, 10, 15, 21, 28, 36, 45, 55 };
    private int _score = 0;

    private void Awake()
    {
        _ballMerger.OnMerged += AddScore;
        UpdateScoreText();
    }

    private void AddScore(int mergedBallSize)
    {
        _score += _scoreTable[mergedBallSize];
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = "Score: " + _score.ToString("00000");
    }
}