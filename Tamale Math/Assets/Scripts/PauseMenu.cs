using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void PauseGame ()
    {
        if (UserInterface.UI.enabled)
        {
            // pause timer
            // pause audio
        }
        else
        {
            Messenger.Broadcast(GameEvent.PAUSE);
        }
    }

    public void ResumeGame ()
    {
        if (PlayerCollision.UI.enabled)
        {
            // unpause timer
            // unpause audio
        }
        else
        {
            Messenger.Broadcast(GameEvent.UNPAUSE);
        }
    }
    public void LoadMainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
