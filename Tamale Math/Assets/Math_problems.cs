using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Question{
    string question;
    string answer;
    string[] multipleChoiceAnswers;
    public Question(string q, string a, string[] multipleChoiceAnswers)
    {
        this.question = q;
        this.answer = a;
        this.multipleChoiceAnswers = multipleChoiceAnswers;
    }
    public string getQuestion()
    {
        return this.question;
    }
    public string getAnswer()
    {
        return this.answer;
    }
    public string[] getMultipleChoiceAnswers()
    {
        return this.multipleChoiceAnswers;
    }
}
