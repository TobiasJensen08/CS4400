using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HittedObject : MonoBehaviour {

    public float startHealth = 1;
    private float health;
    public GameObject TargetExplosion;

    public Image healthBar;
	// Use this for initialization
	void Start () {
        health = startHealth;
        TargetExplosion.SetActive(true);
        TargetExplosion.SetActive(false);
	}

    public void TakeDamage(float amount)
    {
        if (TargetExplosion == null){
            TargetExplosion = new GameObject();
        }
        health -= amount;
        if(health <= 0)
        {
            TargetExplosion.SetActive(true);
            this.gameObject.transform.parent.gameObject.GetComponent<SelfDestruct>().DestroySelf();
            gameObject.SetActive(false);
            Destroy(gameObject);
            FindObjectOfType<AlignWithTarget>().NextTarget();
            
        }
    }
}
