using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Messenger<parameterType>.Broadcast<callbackReturnType>(GameEvent.ENEMY_HIT);
        Messenger<int>.Broadcast(GameEvent.ENEMY_HIT,1);
    }
}
