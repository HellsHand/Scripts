using UnityEngine;
using System.Collections;

public class JumpCheck : MonoBehaviour {

	public Movement moveScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {

		if (col.gameObject.tag == "Floor") {
			moveScript.jumping = false;
		}
	}
	void OnCollisionExit(Collision col) {

		if (col.gameObject.tag == "Floor") {
			moveScript.jumping = true;
		}
	}
}
