using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText; // Use TextMeshProUGUI instead of Text
    
    private Dictionary<string, int> tagToPoints = new Dictionary<string, int>();

    private int score = 0;

    private void Awake()
    {
        instance = this;

        tagToPoints.Add("0", 1);
        tagToPoints.Add("1", 2);
        tagToPoints.Add("2", 3);
        tagToPoints.Add("3", 4);
        tagToPoints.Add("4", 5);
        tagToPoints.Add("5", 6);
        tagToPoints.Add("6", 7);
        tagToPoints.Add("7", 8);
        tagToPoints.Add("8", 9);
    }

    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void AddPoint(string tag)
    {
        if (tagToPoints.ContainsKey(tag))
        {
            score += tagToPoints[tag]; // Add points based on the tag
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public int GetCurrentScore()
    {
        int currentScore = score;
        return score;
    }
}
