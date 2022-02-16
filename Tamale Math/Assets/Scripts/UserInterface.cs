using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public static Canvas UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("Panel").GetComponent<Canvas>();
    }

    public void TogglePanel ()
    {
        UI.enabled = !UI.enabled;
    }

}
