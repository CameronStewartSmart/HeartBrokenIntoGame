using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Result : MonoBehaviour
{
    public Questions questions;
    public GameObject correctSprite;
    public GameObject incorrectSprite;
    public GameObject continueButton;

    public GameObject redFlag1;
    public GameObject redFlag2;
    public GameObject redFlag3;
    public GameObject redFlag4;
    public GameObject redFlag5;
    public GameObject redFlag6;
    public GameObject redFlag7;
    public GameObject redFlag8;
    public GameObject redFlag9;
    public GameObject notAScammerButton;

    public static int quizScore;
    public static int findrScore;
    public static int totalScore;
    public static double likely;

    public Scores scores;

    public Button trueButton;
    public Button falseButton;
    public UnityEvent onNextQuestion;

    void Start()
    {
        correctSprite.SetActive(false);
        incorrectSprite.SetActive(false);

    }

    public void ShowResults(bool answer)
    {
        correctSprite.SetActive(questions.questionsList[questions.currentQuestion].isTrue == answer);
        incorrectSprite.SetActive(questions.questionsList[questions.currentQuestion].isTrue != answer);
    
        if (questions.questionsList[questions.currentQuestion].isTrue == answer){
            quizScore = quizScore + 10;
            totalScore = totalScore + 10;
            scores.AddScore();
            Debug.Log("Total: " + totalScore);
        } else {
            totalScore = totalScore - 10;
            quizScore = quizScore - 10;
            scores.DeductScore();
            Debug.Log("Total: " + totalScore);
        }
        trueButton.interactable = false;
        falseButton.interactable = false;

        StartCoroutine(ShowResults());
    }

    public void Incorrect()
    {
        incorrectSprite.SetActive(true);
        scores.DeductScore();
        findrScore = findrScore - 10;
        totalScore = totalScore - 10;

        redFlag1.SetActive(false);
        redFlag2.SetActive(false);
        redFlag3.SetActive(false);
        redFlag4.SetActive(false);
        redFlag5.SetActive(false);
        redFlag6.SetActive(false);
        redFlag7.SetActive(false);
        redFlag8.SetActive(false);
        redFlag9.SetActive(false);
        notAScammerButton.SetActive(false);
        continueButton.SetActive(true);
    }

    public void Correct()
    {
        correctSprite.SetActive(true);
        scores.AddScore();
        findrScore = findrScore + 10;
        totalScore = totalScore + 10;
        Debug.Log("Total: " + totalScore);

        redFlag1.SetActive(false);
        redFlag2.SetActive(false);
        redFlag3.SetActive(false);
        redFlag4.SetActive(false);
        redFlag5.SetActive(false);
        redFlag6.SetActive(false);
        redFlag7.SetActive(false);
        redFlag8.SetActive(false);
        redFlag9.SetActive(false);
        notAScammerButton.SetActive(false);
        continueButton.SetActive(true);
    }

    private IEnumerator ShowResults()
    {
        yield return new WaitForSeconds(1.0f);

        correctSprite.SetActive(false);
        incorrectSprite.SetActive(false);

        trueButton.interactable = true;
        falseButton.interactable = true;

        onNextQuestion.Invoke();
    }
}
