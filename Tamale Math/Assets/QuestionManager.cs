using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    public Question[] questions;
    public int timerSpeed;
    private static List<Question> unusedQuestions;
    private int gameScore;

    [SerializeField] private TextMeshProUGUI ScoreBoard;
    [SerializeField] private Image timerMeteor;

    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI topLeft;
    [SerializeField] private TextMeshProUGUI topRight;
    [SerializeField] private TextMeshProUGUI bottomLeft;
    [SerializeField] private TextMeshProUGUI bottomRight;


    private Question currentQuestion;
    private List<string> currentAnswers;

    void Start()
    {
        var timer = timerMeteor.GetComponent<TimerMove>();
        if (unusedQuestions == null || unusedQuestions.Count == 0)
        {
            unusedQuestions = questions.ToList<Question>();
            gameScore = 0;
            ScoreBoard.text = gameScore.ToString();
            timer.HSpeed = timerSpeed;
        }
        //else if (unusedQuestions.Count == 0)
        //{
        //    Debug.Log("OUT OF QUESTIONS.");
        //    return;
        //}
        SetCurrentQuestion();
        timer.restart();

    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unusedQuestions.Count);
        currentQuestion = unusedQuestions[randomQuestionIndex];
        currentAnswers = currentQuestion.getAllAnswers().OrderBy(a => Random.value).ToList();

        questionText.text = currentQuestion.question;
        topLeft.text = currentAnswers[0];
        topRight.text = currentAnswers[1];
        bottomLeft.text = currentAnswers[2];
        bottomRight.text = currentAnswers[3];

        unusedQuestions.RemoveAt(randomQuestionIndex);
    }

    public void UserSelectButton(int answerIndex)
    {
        // var answer = EventSystem.current.currentSelectedGameObject.name;
        var answer = currentAnswers[answerIndex];
        if ( answer == currentQuestion.correctAnswer)
        {
            Debug.Log(answer + " IS CORRECT");
            gameScore += 1000;
            ScoreBoard.text = gameScore.ToString();
            // Do something
        }
        else
        {
            Debug.Log(answer + " IS WRONG");
        }

        Start();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
