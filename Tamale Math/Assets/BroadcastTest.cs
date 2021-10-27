using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Messenger.Broadcast(GameEvent.ENEMY_HIT);
    }
}
