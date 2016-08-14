using UnityEngine;
using System.Collections;



public class Movement : MonoBehaviour {

	public int speed = 5; 
	public float grav = 50f;
	public int jump = 100;
	public int speedMultiplier = 100;
	public int jumpMultiplier = 50;
	public bool jumping = false;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float distance = transform.position.x;
		float angle = distance / .01667643f;
		string keyDown = null;

		if (Input.GetKey(KeyCode.D)) {
			GetComponent<Rigidbody>().AddTorque(Vector3.right * speedMultiplier * speed * Time.deltaTime);
			transform.Rotate(Vector3.down * angle);
			keyDown = "right";
		}
		if (Input.GetKey(KeyCode.A)) {
			GetComponent<Rigidbody>().AddForce(Vector3.left * speedMultiplier * speed * Time.deltaTime);
			transform.Rotate(Vector3.up * angle);
			keyDown = "left";
		}
		if (Input.GetKeyDown(KeyCode.Space) && keyDown == null && !jumping) {
			GetComponent<Rigidbody>().AddForce(new Vector3(0, jump * speed, 0));
		}
		else if (Input.GetKeyDown(KeyCode.Space) && keyDown == "right" && !jumping) {
			GetComponent<Rigidbody>().AddForce(new Vector3(speedMultiplier * speed * Time.deltaTime, jump * speed, 0));
		}
		else if (Input.GetKeyDown(KeyCode.Space) && keyDown == "left" && !jumping) {
			GetComponent<Rigidbody>().AddForce(new Vector3(-speedMultiplier * speed * Time.deltaTime, jump * speed, 0));
		}
		Physics.gravity = new Vector3(0, -grav, 0);
	}
}
