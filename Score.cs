using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    
    private int _score;

    private TextMeshProUGUI _scoreText;


    private void Start()
    {
        FillComponents();

        ResetScore();
    }

    public int GetCurrentScore()
    {
        return _score;
    }

    public void ResetScore()
    {
        SetScore(0);
    }

    private void FillComponents()
    {
        _scoreText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void SetScore(int newScore)
    {
        _score = newScore;

        SetScoreText();
    }

    public void ChangeScore(int velue)
    {
        SetScore(velue + _score);
    }
    

    private void SetScoreText()
    {
        _scoreText.text = $"Score: {_score}";
    }
}
