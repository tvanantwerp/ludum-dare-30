using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float maxSpeed = 10f;
	public float jumpForce = 1000f;

	bool facingRight = true;

	bool lowerGround = true;
	float gravity = -30f;

	void Start() {
		Physics2D.gravity = new Vector2 (0, gravity);
	}
	
	// Update is called once per frame
	void Update () {
		float sideMotion = Input.GetAxis ("Horizontal");
		bool jetpack = Input.GetButtonDown("Jump");
		Vector2 pos = transform.position;

		if (jetpack && lowerGround) {
			rigidbody2D.AddForce (Vector3.up * jumpForce);
		}
		else if (jetpack && !lowerGround) {
			rigidbody2D.AddForce (Vector3.up * -jumpForce);	
		}


		pos.x += sideMotion * Time.deltaTime * maxSpeed;
		transform.position = pos;

		if(sideMotion > 0 && !facingRight)
			horizontalFlip ();
		else if(sideMotion < 0 && facingRight)
			horizontalFlip ();
	}

	void FixedUpdate() {
		if (Input.GetButtonDown ("Fire2")) {
			gravity = -gravity;
			Physics2D.gravity = new Vector2 (0, gravity);
			verticalFlip();
		}

	}

	void horizontalFlip() {
		facingRight = !facingRight;
		Quaternion scale = transform.rotation;
		if (scale.y > 0) {
				scale.y = 0;		
		} 
		else {
				scale.y = 180;
		}
		transform.rotation = scale;
	}

	void verticalFlip() {
		lowerGround = !lowerGround;
		Vector3 scale = transform.localScale;
		scale.y *= -1;
		transform.localScale = scale;
	}

}
