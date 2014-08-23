using UnityEngine;
using System.Collections;

public class PlanetRotation : MonoBehaviour {

	public float maxPlanetSpeed = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float forwardMotion = Input.GetAxis ("Vertical");
		float sideMotion = Input.GetAxis ("Horizontal");

		transform.Rotate(Vector3.right * -forwardMotion * maxPlanetSpeed, Space.World); //rotates forward (+) and backward (-)
		transform.Rotate(Vector3.up * sideMotion * maxPlanetSpeed, Space.World); //rotates left (+) and right (-)
	}
}
