using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMove movement;
    public GameObject ShipExplosion;
    public GameObject Cockpit;
    private Canvas UI;

    void Start()
    {
        ShipExplosion.SetActive(true);
        ShipExplosion.SetActive(false);

        this.UI = GameObject.Find("UI").GetComponent<Canvas>();
        this.UI.enabled = false;
        //Speed is governed in AlignWithTarget.cs
        movement.moveSpeed = 0.0f;
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Target")
        {
            FindObjectOfType<GameManager>().ShowThirdPersonCamera();

            ShipExplosion.SetActive(true);
            Cockpit.SetActive(false);
            movement.enabled = false;
            Debug.Log("Astroid Hit!");

            FindObjectOfType<GameManager>().EndGame();
        }
    }


    //Detection of Question Prompts
    void OnTriggerEnter(Collider other) {
        QuestionPrompt();
    }

    void QuestionPrompt(){
        UI.enabled = !UI.enabled;
        Messenger.Broadcast(GameEvent.PAUSE);
    }
}
