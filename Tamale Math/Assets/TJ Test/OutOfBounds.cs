using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        GameObject.Find("Asteroid Setup").GetComponent<AsteroidSetup>().CreateDecorativeAsteroid();
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
