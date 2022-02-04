using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 10f;
    public Camera PlayerCamera;
    public Camera ThirdPersonCamera;


    // Call this function to disable FPS camera,
    // and enable overhead camera.
    public void ShowThirdPersonCamera()
    {
        PlayerCamera.enabled = false;
        ThirdPersonCamera.enabled = true;
    }

    // Call this function to enable FPS camera,
    // and disable overhead camera.
    public void ShowFirstPersonView()
    {
        PlayerCamera.enabled = true;
        ThirdPersonCamera.enabled = false;
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER!");
            // Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

