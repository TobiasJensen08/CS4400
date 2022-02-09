using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public List<Question> questions = new List<Question>();
    public static List<Question> unanswered;
    private static int currentScore;

    private Question currentQuestion;
    private int currentAnswer;

    private float DelayTime = 0.3f;

    [SerializeField]
    private TextMeshProUGUI scoreBoard;
    [SerializeField]
    private TextMeshProUGUI MathQuestion;
    [SerializeField]
    private TextMeshProUGUI TopLeft;        // 0
    [SerializeField]
    private TextMeshProUGUI TopRight;       // 1
    [SerializeField]
    private TextMeshProUGUI BottomRight;    // 2
    [SerializeField]
    private TextMeshProUGUI BottomLeft;     // 3

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        Messenger<int>.AddListener(GameEvent.ANSWER, UserSelect);
        UpdateQuestion();
    }

    public void UpdateQuestion()
    {
        if (unanswered == null || unanswered.Count == 0)
        {
            LoadQuestions();
            unanswered = questions;
        }
        SetCurrentQuestion();
        SetAnswers();
        MathQuestion.text = currentQuestion.content;

    }

    public void LoadQuestions()
    {
        questions.Add(
            new Question("f(x+y)=f(x)+f(y) for all positive integer values of x and y. If f(2)=4, what is the value of f(3)?",
            new string[] { "6", "2", "1", "What?" }));
        questions.Add(
            new Question("30 - 12÷3×2 = ?",
            new string[] { "22", "12", "2", "420" }));
        questions.Add(
            new Question("If -5x + 20 = 25, what is x?",
            new string[] { "-1", "3", "2", "over 9000" }));
        questions.Add(
            new Question("What is the slope of a line perpendicular to the line x = -3?",
            new string[] { "0", "-3", "1", "Cannot tell" }));
        questions.Add(
            new Question("If 2x^2 - 32 = 0, what is x?",
            new string[] { "+-4", "4", "32", "the number of times Timmy ate ice cream last week" }));

    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unanswered.Count);
        currentQuestion = unanswered[randomQuestionIndex];

        unanswered.RemoveAt(randomQuestionIndex);
    }

    IEnumerator TransitionToNextQuestion ()
    {
        yield return new WaitForSeconds(DelayTime);
        UpdateQuestion();
    }

    void SetAnswers()
    {
        List<int> lyst = new List<int>() { 0, 1, 2, 3 };
        var ranLyst = lyst.OrderBy(x => Random.value).ToList();
        currentAnswer = ranLyst.IndexOf(0);
        Debug.Log("Current Answer: "+currentQuestion.choices[ranLyst[currentAnswer]]);

        TopLeft.text = currentQuestion.choices[ranLyst[0]];
        TopRight.text = currentQuestion.choices[ranLyst[1]];
        BottomRight.text = currentQuestion.choices[ranLyst[2]];
        BottomLeft.text = currentQuestion.choices[ranLyst[3]];
    }

    void UserSelect(int choice)
    {
        if (choice == currentAnswer)
        {
            currentAnswer = -1;
            UpdateScore();
            Debug.Log("Right Answer!");
            Messenger.Broadcast("CORRECT_ANSWER");
            // Messenger.Broadcast(GameEvent.CORRECT_ANSWER);
        } else
        {
            Debug.Log("Wrong");
            // Messenger.Broadcast(GameEvent.WRONG_ANSER);
        }

        StartCoroutine(TransitionToNextQuestion());
        GameObject.Find("UI").GetComponent<Canvas>().enabled=false;
        Messenger.Broadcast("UNPAUSE");
    }

    void UpdateScore(int amount = 1000)
    {
        if (amount == 0)
        {
            currentScore = 0;
        }
        else
        {
            currentScore += amount;
        }
        scoreBoard.text = string.Format("{0:n0}", currentScore);
    }

    //Listeners for broadcast events
    private void Awake() {
        //Messenger.AddListener(GameEvent.PROMPT);
        Messenger<int>.AddListener(GameEvent.ANSWER, UserSelect);
    }
    private void OnDestroy() {
        Messenger<int>.RemoveListener(GameEvent.ANSWER, UserSelect);
    }
}
