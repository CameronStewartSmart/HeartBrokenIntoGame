using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Scores : MonoBehaviour
{
    public Text scoreText;
    public Text quizScoreText;
    public Text findrScoreText;
    public Text resultScoreText;
    private int _currentScore;

    public GameObject revealButton;

    void Start()
    {
        //_currentScore = 0;
        scoreText.text = Result.totalScore.ToString();    
    }

    public void AddScore()
    {
        _currentScore += 10;
        scoreText.text = Result.totalScore.ToString();
        quizScoreText.text = Result.quizScore.ToString();
        findrScoreText.text = Result.findrScore.ToString();
    }

    public void DeductScore()
    {
        _currentScore = _currentScore > 0 ? _currentScore - 10 : 0;
        scoreText.text = Result.totalScore.ToString();
        quizScoreText.text = Result.quizScore.ToString();
        findrScoreText.text = Result.findrScore.ToString();
    }

    public void Reveal()
    {
        revealButton.SetActive(false);
        Result.likely = 100 - (Result.totalScore / 2.5);
        resultScoreText.text = Result.likely.ToString();
        quizScoreText.text = Result.quizScore.ToString();
        findrScoreText.text = Result.findrScore.ToString();
    }

}

