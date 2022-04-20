using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMove movement;
    public GameObject ShipExplosion;
    public GameObject Cockpit;
    public static Canvas UI;

    private AudioSource whiteNoise;
    private AudioSource explosion;

    void Start()
    {
        this.whiteNoise = this.gameObject.GetComponents<AudioSource>()[0];
        this.explosion = this.gameObject.GetComponents<AudioSource>()[1];

        UI = GameObject.Find("Panel").GetComponent<Canvas>();
        UI.enabled = false;
        //Speed is governed in AlignWithTarget.cs
        //movement.moveSpeed = 0.0f;
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        //Player Death
        if (collisionInfo.collider.tag == "Target")
        {
            this.explosion.Play();
            ToggleNoise();
            FindObjectOfType<GameManager>().ShowThirdPersonCamera();

            ShipExplosion.SetActive(true);
            Cockpit.SetActive(false);
            movement.enabled = false;

            FindObjectOfType<GameManager>().EndGame();
        }
    }


    void FireLaser(){
        var blaster1 = GameObject.Find("Blaster1");
        var blaster2 = GameObject.Find("Blaster2");

        blaster1.GetComponent<Hovl_DemoLasers>().FireLaser();
        blaster1.GetComponent<AudioSource>().Play();
        blaster2.GetComponent<Hovl_DemoLasers>().FireLaser();
        blaster2.GetComponent<AudioSource>().Play();

        ToggleNoise();
    }
    void ToggleNoise()
    {
        if (this.whiteNoise.isPlaying)
        {
            this.whiteNoise.Stop();
        }
        else
        {
            this.whiteNoise.Play();
        }
    }

    //Detection of Question Prompts
    void OnTriggerEnter(Collider other) {
        QuestionPrompt();
    }

    void QuestionPrompt(){
        UI.enabled = !UI.enabled;
        this.whiteNoise.Stop();
        Messenger.Broadcast(GameEvent.PROMPT);
    }

    //Listen for correct answer
    private void Awake() {
        Messenger.AddListener("CORRECT_ANSWER", FireLaser);
        Messenger.AddListener("WRONG_ANSWER", ToggleNoise);
    }
    private void OnDestroy() {
        Messenger.RemoveListener("CORRECT_ANSWER", FireLaser);
        Messenger.AddListener("WRONG_ANSWER", ToggleNoise);
    }

}
