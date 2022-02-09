using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Question
{
    public string content { get; }
    // the correct answer is always the first item in the list
    public string[] choices { get; }

    private int correctAnswerIndex;

    public Question(string content, string[] choices, int correctAnswerIndex = 0)
    {
        this.content = content;
        this.choices = choices;
        this.correctAnswerIndex = correctAnswerIndex;
    }

    public bool IsCorrect(int guessIndex)
    {
    	return this.correctAnswerIndex == guessIndex;
    }
}