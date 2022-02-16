using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorldTJ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, World. -- From Tobias Jensen");
    }

    void Awake() {
        Messenger<int>.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    void OnDestroy() {
        Messenger<int>.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    private void OnEnemyHit(int i){
        Debug.Log("Enemy Hit" + i);
    }
}