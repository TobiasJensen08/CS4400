using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMove movement;
    public GameObject ShipExplosion;
    public GameObject Cockpit;
    public static Canvas UI;

    void Start()
    {
        ShipExplosion.SetActive(true);
        ShipExplosion.SetActive(false);

        UI = GameObject.Find("Panel").GetComponent<Canvas>();
        UI.enabled = false;
        //Speed is governed in AlignWithTarget.cs
        movement.moveSpeed = 0.0f;
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        //Player Death
        if (collisionInfo.collider.tag == "Target")
        {
            FindObjectOfType<GameManager>().ShowThirdPersonCamera();

            ShipExplosion.SetActive(true);
            Cockpit.SetActive(false);
            movement.enabled = false;
            Debug.Log("Astroid Hit!");

            FindObjectOfType<GameManager>().EndGame();

            this.GetComponent<AlignWithTarget>().Stop();
        }
    }


    void FireLaser(){
        Debug.Log("Fire");
        var blaster1 = GameObject.Find("Blaster1");
        var blaster2 = GameObject.Find("Blaster2");
        blaster1.GetComponent<Hovl_DemoLasers>().FireLaser();
        blaster2.GetComponent<Hovl_DemoLasers>().FireLaser();
    }
    //Detection of Question Prompts
    void OnTriggerEnter(Collider other) {
        Debug.Log("Prompt");
        //FireLaser();
        QuestionPrompt();
    }

    void QuestionPrompt(){
        UI.enabled = !UI.enabled;
        Messenger.Broadcast(GameEvent.PAUSE);
    }

    //Listen for correct answer
    private void Awake() {
        Messenger.AddListener("CORRECT_ANSWER", FireLaser);
    }
    private void OnDestroy() {
        Messenger.RemoveListener("CORRECT_ANSWER", FireLaser);
    }

}
