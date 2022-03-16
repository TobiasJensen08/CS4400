using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3;
    public float leftRightSpeed = 4;
    private float currSpeed;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * currSpeed, Space.World);
        if (Input.GetKey(KeyCode.A)){
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide){
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D)){
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide){
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }
        }
    }

    private void Awake()
    {
        currSpeed = moveSpeed;
        //Messenger.AddListener("PAUSE", Stop);
        Messenger.AddListener("PROMPT", Stop);
        Messenger.AddListener("UNPAUSE", Unpause);
    }
    private void OnDestroy()
    {
        //Messenger.RemoveListener("PAUSE", Stop);
        Messenger.RemoveListener("UNPAUSE", Unpause);
        Messenger.RemoveListener("PROMPT", Stop);
    }
    public void Stop()
    {
        currSpeed = 0.0f;
    }
    private void Unpause()
    {
        currSpeed = moveSpeed;
    }



    // public float acceleration = 150; // how fast you accelerate
    // public float accSprintMultiplier = 4; // how much faster you go when "sprinting"
    // public float lookSensitivity = 1; // mouse look sensitivity
    // public float dampingCoefficient = 5; // how quickly you break to a halt after you stop your input
    // public bool focusOnEnable = false; // whether or not to focus and lock cursor immediately on enable

    // Vector3 velocity; // current velocity

    // static bool Focused
    // {
    //     get => Cursor.lockState == CursorLockMode.Locked;
    //     set
    //     {
    //         Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
    //         Cursor.visible = value == false;
    //     }
    // }

    // void OnEnable()
    // {
    //     if (focusOnEnable) Focused = true;
    // }

    // void OnDisable() => Focused = false;

    // void Update()
    // {
    //     // Input
    //     if (Focused)
    //         UpdateInput();
    //     else if (Input.GetMouseButtonDown(0))
    //         Focused = true;

    //     // Physics
    //     velocity = Vector3.Lerp(velocity, Vector3.zero, dampingCoefficient * Time.deltaTime);
    //     transform.position += velocity * Time.deltaTime;
    // }

    // void UpdateInput()
    // {
    //     // Position
    //     velocity += GetAccelerationVector() * Time.deltaTime;

    //     // Rotation
    //     Vector2 mouseDelta = lookSensitivity * new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
    //     Quaternion rotation = transform.rotation;
    //     Quaternion horiz = Quaternion.AngleAxis(mouseDelta.x, Vector3.up);
    //     Quaternion vert = Quaternion.AngleAxis(mouseDelta.y, Vector3.right);
    //     transform.rotation = horiz * rotation * vert;

    //     // Leave cursor lock
    //     if (Input.GetKeyDown(KeyCode.Escape))
    //         Focused = false;
    // }

    // Vector3 GetAccelerationVector()
    // {
    //     Vector3 moveInput = default;

    //     void AddMovement(KeyCode key, Vector3 dir)
    //     {
    //         if (Input.GetKey(key))
    //             moveInput += dir;
    //     }

    //     AddMovement(KeyCode.W, Vector3.forward);
    //     AddMovement(KeyCode.S, Vector3.back);
    //     AddMovement(KeyCode.D, Vector3.right);
    //     AddMovement(KeyCode.A, Vector3.left);
    //     AddMovement(KeyCode.Space, Vector3.up);
    //     AddMovement(KeyCode.LeftControl, Vector3.down);
    //     Vector3 direction = transform.TransformVector(moveInput.normalized);

    //     if (Input.GetKey(KeyCode.LeftShift))
    //         return direction * (acceleration * accSprintMultiplier);
    //     return direction * acceleration;
    // }
}
