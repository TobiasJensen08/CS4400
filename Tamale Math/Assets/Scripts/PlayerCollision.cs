using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMove movement;
    public GameObject ShipExplosion;
    public GameObject Cockpit;

    void Start()
    {
        ShipExplosion.SetActive(true);
        ShipExplosion.SetActive(false);
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
    void OnTriggerEnter(Collider other) {
        QuestionPrompt();
    }

    void QuestionPrompt(){
        Debug.Log("Prompt");
    }
}
