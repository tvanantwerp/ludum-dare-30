using UnityEngine;
using System.Collections;

public class SpaceTracking : MonoBehaviour {

	public float levelSpeed = 5f;
	public GameObject player;
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		Vector3 player_pos = player.transform.position;
		pos.x = player_pos.x;
		pos.y += levelSpeed * Time.deltaTime;
		transform.position = pos;
	}
}
