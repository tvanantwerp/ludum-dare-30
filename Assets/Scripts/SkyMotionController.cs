using UnityEngine;
using System.Collections;

public class SkyMotionController : MonoBehaviour {

	public GameObject player;
	public float parallaxSpeed = 0.1f;
	public Vector3 lastPlayerPosition;
	public float windSpeed = 0.01f;
	
	void Start() {
		player = GameObject.Find ("Player");
		lastPlayerPosition = player.transform.position;
	}

	void Update() {
		Vector3 skyPosition = transform.position;
		Vector3 playerPosition = player.transform.position;
		float playerMotion = playerPosition.x - lastPlayerPosition.x;
		skyPosition.x = skyPosition.x + (playerMotion * parallaxSpeed) - windSpeed;
		transform.position = skyPosition;
		lastPlayerPosition = player.transform.position;
	}
	
}
