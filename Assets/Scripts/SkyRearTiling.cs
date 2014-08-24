using UnityEngine;
using System.Collections;

public class SkyRearTiling : MonoBehaviour {
	public float defaultWidth = 81.92f;
	public float defaultTiles = 4f;
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.name == "sky") {
			Vector2 pos = collider.transform.position;
			pos.x += defaultWidth * defaultTiles;
			collider.transform.position = pos;
		} 
	}
}
