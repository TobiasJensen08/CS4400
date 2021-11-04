using UnityEngine;
using System.Collections.Generic;

/*
public class ClassName{
    string question;
    string[] answers;
    int correctIndex;

    [SerializeField] private Text questionDisplay;
    [SerializeField] private Text topLeft;
    // etc.
}
*/
/*
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

public abstract class GradeLevel
{
    protected List<Question> questions;
    private int currentIdx = 0;
    public string getNextsQuestion()
    {
        if(questions.Count > currentIdx)
        {
            return questions[currentIdx].getQuestion();
        }
        return "It's time to Level Up!!!";
    }

    public bool isCorrectAnser(string answer)
    {
        if(questions[currentIdx].getAnswer() == answer)
        {
            currentIdx++;
            return true;
        }
        return false;
    }
    bool canLevelUp()
    {
        return currentIdx == questions.Count;
    }
}

public class Kindergarten : GradeLevel
{
    public Kindergarten(){
        this.questions = new List<Question>();
        this.questions.Add(new Question("1 + 1", "2"));
        this.questions.Add(new Question("2 + 2", "3"));
        this.questions.Add(new Question("2 + 2", "4"));
        this.questions.Add(new Question("3 + 3", "6"));
        this.questions.Add(new Question("3 + 3", "5"));
        this.questions.Add(new Question("4 + 4", "8"));
        this.questions.Add(new Question("4 + 4", "5"));
        this.questions.Add(new Question("5 + 5", "2")); 
        this.questions.Add(new Question("5 + 5", "10"));  
        this.questions.Add(new Question("3 + 1", "3")); 
        this.questions.Add(new Question("1 + 3", "4"));
        this.questions.Add(new Question("1 + 2", "3"));
        this.questions.Add(new Question("2 + 1", "3"));
        this.questions.Add(new Question("4 - 2", "2"));  
        this.questions.Add(new Question("2 - 2", "0"));
        this.questions.Add(new Question("2 - 1", "1"));
        this.questions.Add(new Question("2 - 2", "1"));
        this.questions.Add(new Question("5 - 2", "3"));
        this.questions.Add(new Question("5 - 1", "4"));     
          
    }
}

public class FirstGrade : GradeLevel
{
    public FirstGrade()
    {
        this.questions = new List<Question>();
        this.questions.Add(new Question("6 - 5", "2"));
        this.questions.Add(new Question("6 - 5", "1"));
        this.questions.Add(new Question("9 - 3", "6"));
        this.questions.Add(new Question("8 - 2", "6"));
        this.questions.Add(new Question("6 + 8", "14"));
        this.questions.Add(new Question("8 - 6", "2"));
        this.questions.Add(new Question("9 + 5", "14"));
        this.questions.Add(new Question("10 - 2", "8"));
        this.questions.Add(new Question("2 + 10", "11"));
        this.questions.Add(new Question("10 - 6", "4"));
        this.questions.Add(new Question("8 - 7", "2"));
        this.questions.Add(new Question("9 - 2", "5"));           
    }
}

public class SecondGrade : GradeLevel{
    public SecondGrade()
    {
        this.questions = new List<Question>();
        this.questions.Add(new Question("10 + 3", "13"));
        this.questions.Add(new Question("7 + 4", "11")); 
        this.questions.Add(new Question("6 + 6", "12"));
        this.questions.Add(new Question("5 + 6", "11")); 
        this.questions.Add(new Question("6 + 7", "13"));
        this.questions.Add(new Question("7 + 6", "12")); 
        this.questions.Add(new Question("10 - 3", "9"));
        this.questions.Add(new Question("7 - 4", "3")); 
        this.questions.Add(new Question("6 - 6", "0"));
        this.questions.Add(new Question("11 - 3", "8")); 
        this.questions.Add(new Question("11 - 8", "4"));
        this.questions.Add(new Question("14 - 2", "12")); 
   
    }

}

public class ThirdGrade : GradeLevel{

    public ThirdGrade(){
        this.questions = new List<Question>();
        this.questions.Add(new Question("x + 3 < 14", "5"));
        this.questions.Add(new Question("9 + x > 18", "11")); 
        this.questions.Add(new Question("20 % 5", "4"));
        this.questions.Add(new Question("5 % 5", "1")); 
        this.questions.Add(new Question("20 % 4", "6"));
        this.questions.Add(new Question("2 x 6", "12")); 
        this.questions.Add(new Question("3 x 3", "9"));
        this.questions.Add(new Question("4 x 4", "8")); 
        this.questions.Add(new Question("6 % 6", "0"));
        this.questions.Add(new Question("801 - 99", "702")); 
        this.questions.Add(new Question("859 - 54", "804"));
        this.questions.Add(new Question("337 + 334", "678")); 

    }
}
public class FourdGrade : GradeLevel{

    public FourdGrade(){
        this.questions = new List<Question>();
        this.questions.Add(new Question("9 + 3 + 2 + 8", "21"));
        this.questions.Add(new Question("2 + 3 + 7 + 4 + 5", "11")); 
        this.questions.Add(new Question("60 % 5", "12"));
        this.questions.Add(new Question("120 % 3", "40")); 
        this.questions.Add(new Question("20 x 4", "82"));
        this.questions.Add(new Question("25 x 6", "150")); 
        this.questions.Add(new Question("11 x 3", "30"));
        this.questions.Add(new Question("4 x 4", "16")); 
        this.questions.Add(new Question("60 % 6", "10"));
        this.questions.Add(new Question("801 + 99", "900")); 
        this.questions.Add(new Question("85 + 540", "543"));
        this.questions.Add(new Question("337 - 334", "5")); 

    }
}*/




