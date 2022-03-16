using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardFlight : MonoBehaviour
{

    public float flightSpeed = 1;
    private float currSpeed;

    public static Canvas UI;

    // Start is called before the first frame update
    void Start()
    {
        currSpeed = flightSpeed;
        UI = GameObject.Find("Panel").GetComponent<Canvas>();
        UI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * currSpeed * Time.deltaTime);
    }

    private void Awake()
    {
        //Messenger.AddListener("PAUSE", Stop);
        Messenger.AddListener("PROMPT", Stop);
        Messenger.AddListener("UNPAUSE", Unpause);
    }
    private void OnDestroy()
    {
        //Messenger.RemoveListener("PAUSE", Stop);
        Messenger.RemoveListener("UNPAUSE", Unpause);
        Messenger.RemoveListener("PROMPT", Stop);
    }
    public void Stop()
    {
        Debug.Log("Stopping");
        currSpeed = 0.0f;
    }
    private void Unpause()
    {
        currSpeed = flightSpeed;
    }
}
