using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public void DestroySelf()
    {
        this.GetComponent<AudioSource>().Play();
        StartCoroutine(DelayedDestruction());
    }

    IEnumerator DelayedDestruction()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
