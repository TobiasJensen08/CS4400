// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMove : MonoBehaviour
// {
//     // public float moveSpeed = 10;
//     public float throttleSpeed = 10;
//     public float leftRightSpeed = 20;
//     public float upDownSpeed = 20;
//     public float boostSpeed = 10;


//     // Update is called once per frame
//     void Update()
//     {
//         // transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

//         if (Input.GetKey(KeyCode.Space))
//         {
//             transform.Translate(Vector3.forward * Time.deltaTime * throttleSpeed);
//         }

//         if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
//         {
//             transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
//         }

//         if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
//         {
//             transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed * -1);
//         }

//         if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
//         {
//             transform.Translate(Vector3.up * Time.deltaTime * upDownSpeed);
//         }

//         if (Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
//         {
//             transform.Translate(Vector3.down * Time.deltaTime * upDownSpeed * -1);
//         }

//         if (Input.GetKey(KeyCode.LeftShift))
//         {
//             transform.Translate(Vector3.forward * Time.deltaTime * (throttleSpeed+boostSpeed));
//         }
//     }
// }

using UnityEngine;

// [RequireComponent( typeof(Camera) )]
public class PlayerMove : MonoBehaviour {
	public float acceleration = 150; // how fast you accelerate
	public float accSprintMultiplier = 4; // how much faster you go when "sprinting"
	public float lookSensitivity = 1; // mouse look sensitivity
	public float dampingCoefficient = 5; // how quickly you break to a halt after you stop your input
	public bool focusOnEnable = true; // whether or not to focus and lock cursor immediately on enable

	Vector3 velocity; // current velocity

	static bool Focused {
		get => Cursor.lockState == CursorLockMode.Locked;
		set {
			Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
			Cursor.visible = value == false;
		}
	}

	void OnEnable() {
		if( focusOnEnable ) Focused = true;
	}

	void OnDisable() => Focused = false;

	void Update() {
		// Input
		if( Focused )
			UpdateInput();
		else if( Input.GetMouseButtonDown( 0 ) )
			Focused = true;

		// Physics
		velocity = Vector3.Lerp( velocity, Vector3.zero, dampingCoefficient * Time.deltaTime );
		transform.position += velocity * Time.deltaTime;
	}

	void UpdateInput() {
		// Position
		velocity += GetAccelerationVector() * Time.deltaTime;

		// Rotation
		Vector2 mouseDelta = lookSensitivity * new Vector2( Input.GetAxis( "Mouse X" ), -Input.GetAxis( "Mouse Y" ) );
		Quaternion rotation = transform.rotation;
		Quaternion horiz = Quaternion.AngleAxis( mouseDelta.x, Vector3.up );
		Quaternion vert = Quaternion.AngleAxis( mouseDelta.y, Vector3.right );
		transform.rotation = horiz * rotation * vert;

		// Leave cursor lock
		if( Input.GetKeyDown( KeyCode.Escape ) )
			Focused = false;
	}

	Vector3 GetAccelerationVector() {
		Vector3 moveInput = default;

		void AddMovement( KeyCode key, Vector3 dir ) {
			if( Input.GetKey( key ) )
				moveInput += dir;
		}

		AddMovement( KeyCode.W, Vector3.forward );
		AddMovement( KeyCode.S, Vector3.back );
		AddMovement( KeyCode.D, Vector3.right );
		AddMovement( KeyCode.A, Vector3.left );
		AddMovement( KeyCode.Space, Vector3.up );
		AddMovement( KeyCode.LeftControl, Vector3.down );
		Vector3 direction = transform.TransformVector( moveInput.normalized );

		if( Input.GetKey( KeyCode.LeftShift ) )
			return direction * ( acceleration * accSprintMultiplier ); // "sprinting"
		return direction * acceleration; // "walking"
	}
}