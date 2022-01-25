using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAsteroidSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Bounds bounds = GetComponent<Collider>().bounds;
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
        float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
