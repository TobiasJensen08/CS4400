using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSetup : MonoBehaviour
{
    public List<GameObject> asteroids;
    public GameObject questionPrompt;
    public GameObject promptingAsteroid;
    public float maxViewDistance;
    public int decorativeAsteroids = 20;
    public int promptingAsteroids = 10;
    public float promptAsteroidDistance = 30;
    public float distBetweenAsteroidAndPrompts = 15;

    private Bounds flyZone;
    private Camera camera;

    //Keeps track of last prompting asteroid
    private GameObject lastPrompter;

    void Awake()
    {
        camera = Camera.main;
        flyZone = GameObject.Find("Fly Zone").GetComponent<BoxCollider>().bounds;
        
        for(int i=0; i< decorativeAsteroids; i++)
        {
            CreateDecorativeAsteroid(true);
        }

        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        lastPrompter = new GameObject();
        lastPrompter.transform.position = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z + (promptAsteroidDistance * 2));
        for(int i=0; i < promptingAsteroids; i++)
        {
            CreatePromptingAsteroid();
        }

        //Event Listeners
        Messenger.AddListener("CORRECT_ANSWER", CreatePromptingAsteroid);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener("CORRECT_ANSWER", CreatePromptingAsteroid);
    }

    private void CreatePromptingAsteroid()
    {
        Vector3 pointInFlight = new Vector3(lastPrompter.transform.position.x, lastPrompter.transform.position.y, lastPrompter.transform.position.z + promptAsteroidDistance);
        lastPrompter = Instantiate(this.promptingAsteroid, pointInFlight, Quaternion.identity);
    }

    public void CreateDecorativeAsteroid(bool gameBeginning = false)
    {
        Vector3 pointInView = FindPoint(gameBeginning);
        GameObject asteroid = Instantiate(asteroids[Random.Range(0, asteroids.Count)], pointInView, Random.rotation);
        asteroid.transform.localScale = new Vector3(5, 5, 5);
        asteroid.AddComponent<OutOfBounds>();
        asteroid.AddComponent<MeshRenderer>();
        asteroid.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
    }

    private Vector3 FindPointHelper(bool gameBeginninng)
    {
        float x = Random.Range(0, Screen.width);
        float y = Random.Range(0, Screen.height);
        //float z = Random.Range(0, maxViewDistance);
        float z = (gameBeginninng) ? Random.Range(0, maxViewDistance) : maxViewDistance;
        //ScreenToWorldPoint: converts screen coords (x,y) + distance from camera (z) to world point
        return camera.ScreenToWorldPoint(new Vector3(x, y, z));
    }
    private Vector3 FindPoint(bool gameBeginninng)
    {
        Vector3 point = FindPointHelper(gameBeginninng);
        while (flyZone.Contains(point))
        {
            point = FindPointHelper(gameBeginninng);
        }
        return point;
    }
}
