using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {

	public float maxShipSpeed = 20f;
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		float sideMotion = Input.GetAxis ("Horizontal");
		float vertMotion = Input.GetAxis ("Vertical");

		pos.y += vertMotion * Time.deltaTime * maxShipSpeed;
		pos.x += sideMotion * Time.deltaTime * maxShipSpeed;

		transform.position = pos;
	}
}
