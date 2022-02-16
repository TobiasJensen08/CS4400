using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string currentLevel;
    public void PlayGame ()
    {
        //TODO: Get the current level selection and load the approprate level scene
        currentLevel = "Demo";
        SceneManager.LoadScene(currentLevel);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
