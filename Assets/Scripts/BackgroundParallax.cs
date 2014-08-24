using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour {

	public GameObject player;
	public float parallaxSpeed = 0.1f;
	public Vector3 lastPlayerPosition;

	void Start() {
		player = GameObject.Find ("Player");
		lastPlayerPosition = player.transform.position;
	}

	// Update is called once per frame
	void Update () {
		Vector3 bgPosition = transform.position;
		Vector3 playerPosition = player.transform.position;
		float playerMotion = playerPosition.x - lastPlayerPosition.x;
		bgPosition.x = (bgPosition.x + playerMotion * parallaxSpeed);
		transform.position = bgPosition;
		lastPlayerPosition = player.transform.position;
	}
}
