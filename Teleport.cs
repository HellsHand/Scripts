using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	public Transform player;
	private Vector3 startLoc = new Vector3(12.382f, -12.98039f, 0);

	void OnTriggerEnter(Collider collided) {
		if(collided.tag == "tele") {
			//player.Translate(Vector3.right * .604f);
			player.position = startLoc;
		}
		
	}
}
