using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    private void Start()
    {
        Messenger.AddListener("SCENE_SWITCH", OnApplicationQuit);
    }
    private void OnDestroy()
    {
        OnApplicationQuit();
        Messenger.RemoveListener("SCENE_SWITCH", OnApplicationQuit);
    }

    private bool redraw = true;
    //Disable respawning of asteroids.
    //OnApplicationQuit fires when app is shut down, useful to prevent errors in all cases.
    private void OnApplicationQuit()
    {
        redraw = false;
    }

    private void OnBecameInvisible()
    {
        if (redraw)
        {
            GameObject.Find("Asteroid Setup").GetComponent<AsteroidSetup>().CreateDecorativeAsteroid();
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        
    }
}
