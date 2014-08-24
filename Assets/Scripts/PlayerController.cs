using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	
	public float maxSpeed = 10f;
	public float jumpForce = 1000f;
	bool jetpack = false;
	bool dead = false;

	Animator animator;

	bool facingRight = true;

	bool lowerGround = true;
	float gravity = -30f;

	List<string> killers = new List<string>();

	void Start() {
		Physics2D.gravity = new Vector2 (0, gravity);

		animator = GetComponent<Animator>();

		// Define things that kill you
		killers.Add ("LowPlatform");
		killers.Add ("HighPlatform");
		killers.Add ("Small Spikes");
		killers.Add ("Large Spikes");
		killers.Add ("Bottomless Pit");
	}
	
	// Update is called once per frame
	void Update () {
		if (dead)
			return;

		float sideMotion = Input.GetAxis ("Horizontal");
		jetpack = (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"));
		Vector2 pos = transform.position;

		pos.x += sideMotion * Time.deltaTime * maxSpeed;
		transform.position = pos;

		if (sideMotion > 0 && !facingRight) {
			horizontalFlip ();
		}
		else if (sideMotion < 0 && facingRight) {
			horizontalFlip ();
		}
	}

	void FixedUpdate() {
		if (dead)
			return;

		if (Input.GetButtonDown ("Fire2")) {
			gravity = -gravity;
			Physics2D.gravity = new Vector2 (0, gravity);
			verticalFlip();
		}

		if (jetpack && lowerGround) {
			rigidbody2D.AddForce (Vector3.up * jumpForce);
			animator.SetTrigger("Jump");
			jetpack = false;
		}
		else if (jetpack && !lowerGround) {
			rigidbody2D.AddForce (Vector3.up * -jumpForce);
			animator.SetTrigger("Jump");
			jetpack = false;
		}

	}

	void horizontalFlip() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	void verticalFlip() {
		lowerGround = !lowerGround;
		Vector3 scale = transform.localScale;
		scale.y *= -1;
		transform.localScale = scale;
	}

	void OnCollisionEnter2D(Collision2D collision){
		foreach (string killer in killers) {
			if (collision.gameObject.name == killer) {
					animator.SetTrigger ("PlayerDead");
					dead = true;
			}
		}
	}

}
