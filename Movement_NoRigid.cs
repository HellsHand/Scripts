using UnityEngine;
using System.Collections;

public class Movement_NoRigid : MonoBehaviour {
	public float speed = 2.5f;
	private Animator animator;
	private int lastKey = 0;
	private RaycastHit hit;
	public bool stop = false;
	private float loc = 0;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		//horizontal movement
		if (Input.GetKeyDown(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && stop == false) {
			animator.SetInteger("direction", 1);
			transform.Translate(Vector2.right * Time.deltaTime * speed);
			lastKey = 1;
			if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z), transform.TransformDirection(Vector3.right), out hit, .125f) || 
			   Physics.Raycast(new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z), transform.TransformDirection(Vector3.right), out hit, .125f) ||
			   Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.right), out hit, .125f)) {
				if(hit.collider.tag == "wall") {
					loc = hit.transform.position.x;
					stop = true;
					transform.Translate(-Vector2.right * Time.deltaTime * speed);
					print (loc);
				}
			}
		}
		else if(Input.GetKeyUp(KeyCode.D)) {
			animator.SetInteger("direction", 5);
			stop = false;
			
		}
		if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && stop == false) {
			animator.SetInteger("direction", 3);
			transform.Translate(-Vector2.right * Time.deltaTime * speed);
			lastKey = 3;
			if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z), transform.TransformDirection(Vector3.left), out hit, .115f) || 
			   Physics.Raycast(new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z), transform.TransformDirection(Vector3.left), out hit, .115f) ||
			   Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.left), out hit, .115f)) {
				if(hit.collider.tag == "wall") {
					stop = true;
					transform.Translate(Vector2.right * Time.deltaTime * speed);

				}
			}
		}
		else if(Input.GetKeyUp(KeyCode.A)) {
			animator.SetInteger("direction", 4);
			stop = false;

		}

		//vertical movement
		if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && stop == false) {
			animator.SetInteger("direction", 0);
			transform.Translate(Vector2.up * Time.deltaTime * speed);
			lastKey = 0;
			if(Physics.Raycast(new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.up), out hit, .125f) || 
			   Physics.Raycast(new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.up), out hit, .125f) ||
			   Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.up), out hit, .125f)) {
				if(hit.collider.tag == "wall") {
					stop = true;
					transform.Translate(-Vector2.up * Time.deltaTime * speed);

				}
			}
		}
		else if(Input.GetKeyUp(KeyCode.W)) {
			animator.SetInteger("direction", 6);
			stop = false;

		}
		if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && stop == false) {
			animator.SetInteger("direction", 2);
			transform.Translate(-Vector2.up * Time.deltaTime * speed);
			lastKey = 2;
			if(Physics.Raycast(new Vector3(transform.position.x - .1f, transform.position.y - .1f, transform.position.z), transform.TransformDirection(Vector3.down), out hit, .045f) || 
			   Physics.Raycast(new Vector3(transform.position.x + .1f, transform.position.y - .1f, transform.position.z), transform.TransformDirection(Vector3.down), out hit, .045f) ||
			   Physics.Raycast(new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z), transform.TransformDirection(Vector3.down), out hit, .045f)) {
				if(hit.collider.tag == "wall") {
					stop = true;
					transform.Translate(Vector2.up * Time.deltaTime * speed);

				}
			}
		}
		else if(Input.GetKeyUp(KeyCode.S)) {
			animator.SetInteger("direction", 7);
			stop = false;

		}

		//cancel movement if more than 1 button down
		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) {
			transform.Translate(Vector2.zero);
			if(lastKey == 3) {
				animator.SetInteger("direction", 4);
			}
			else if(lastKey == 1) {
				animator.SetInteger("direction", 5);
			}
		}
		if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) {
			transform.Translate(Vector2.zero);
			if(lastKey == 0) {
				animator.SetInteger("direction", 6);
			}
			else if(lastKey == 2) {
				animator.SetInteger("direction", 7);
			}
		}
		if(Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))) {
			transform.Translate(Vector2.zero);
			if(lastKey == 3) {
				animator.SetInteger("direction", 4);
			}
			else if(lastKey == 0) {
				animator.SetInteger("direction", 6);
			}
			else if(lastKey == 2) {
				animator.SetInteger("direction", 7);
			}
		}
		if(Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))) {
			transform.Translate(Vector2.zero);
			if(lastKey == 1) {
				animator.SetInteger("direction", 5);
			}
			else if(lastKey == 0) {
				animator.SetInteger("direction", 6);
			}
			else if(lastKey == 2) {
				animator.SetInteger("direction", 7);
			}
		}

		if (stop == true) {
			transform.Translate(Vector2.zero);
		}

	}
}
