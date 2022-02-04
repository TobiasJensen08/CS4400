using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Question
{
    public string content;
    // the correct answer is always the first item in the list
    public string[] choices;

    public Question(string c, string[] a)
    {
        content = c;
        choices = a;
    }
}