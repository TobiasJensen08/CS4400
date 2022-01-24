using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 1000;
    public bool creatingSection = false;
    public bool gameHasEnded = false;
    public int secNum;
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine (GenerateSection());
        }
    }
    IEnumerator GenerateSection()
    {
        if(gameHasEnded==false)
        {
            secNum = Random. Range(0, 3);
            Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
            zPos += 1000;
            yield return new WaitForSeconds(5);
            creatingSection = false;
        }
    }
}