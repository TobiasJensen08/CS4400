using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float maxSpeed = 1;
    private Vector3 rotation;
    // Start is called before the first frame update
    //void Start()
    void Awake()
    {
        rotation.x = Random.Range(0, maxSpeed);
        rotation.y = Random.Range(0, maxSpeed);
        rotation.z = Random.Range(0, maxSpeed);
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
