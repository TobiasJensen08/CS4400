using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HittedObject1 : MonoBehaviour {

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
	
	// Update is called once per frame
	void Update () {
		
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
            //Debug.Log("Astroid Destroyed!");
            gameObject.SetActive(false);
            Debug.Log(this.gameObject.transform.parent.name);
            Destroy(this.gameObject.transform.parent.gameObject);
            //FindObjectOfType<AlignWithTarget>().NextTarget();
        }
    }
}
