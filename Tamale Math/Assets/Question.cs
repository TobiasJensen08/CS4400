using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Question
{
    public string question;
    public string correctAnswer;
    public string wrongAnswer1;
    public string wrongAnswer2;
    public string wrongAnswer3;

    public List<string> getAllAnswers()
    {
        return new List<string> { correctAnswer, wrongAnswer1, wrongAnswer2, wrongAnswer3 };
    }
}

