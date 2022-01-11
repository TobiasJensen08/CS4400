using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Broadcast with parameter: <int> after Messenger, event, parameter
        Messenger<int>.Broadcast(GameEvent.ENEMY_HIT, 1);
    }
}
