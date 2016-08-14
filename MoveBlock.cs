using UnityEngine;
using System.Collections;

public class MoveBlock : MonoBehaviour {

	private Animator animator;
	private RaycastHit hit;
	private int lastStopped = 0;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		//horizontal movement
		
		if(Input.GetKeyDown(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A)) {
			lastStopped = 0;
			animator.SetInteger("direction", 1);
			if((!Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.right), out hit, .302f) 
			&& lastStopped != 1) || (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.right), out hit, .302f) && hit.collider.tag != "wall")) {
				transform.Translate(Vector2.right * .302f);
				if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.right), out hit, .302f)) {
					if(hit.collider.tag == "wall") {

						lastStopped = 1;
					}
				}
			} 
		}
		if(Input.GetKeyUp(KeyCode.D)) {
			animator.SetInteger ("direction", 5);
		}

		
		if(Input.GetKeyDown(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D)) {
			lastStopped = 0;
			animator.SetInteger("direction", 3);
			if(!Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.left), out hit, .302f) && lastStopped != 2 || hit.collider.tag != "wall") {
				transform.Translate(-Vector2.right * .302f);
				if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.left), out hit, .302f)) {
					if(hit.collider.tag == "wall") {

						lastStopped = 2;
					}
				}
			}
		}
		if(Input.GetKeyUp(KeyCode.A)) {
			animator.SetInteger("direction", 4);
		}

		//vertical movement
		
		if (Input.GetKeyDown(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S)) {
			lastStopped = 0;
			animator.SetInteger("direction", 0);
			if(!Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.up), out hit, .302f) && lastStopped != 3 || hit.collider.tag != "wall") {
				transform.Translate(Vector2.up * .302f);
				if(Physics.Raycast(new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.up), out hit, .302f)) {
					if(hit.collider.tag == "wall") {

						lastStopped = 3;
					}
				}
			}
		}
		if(Input.GetKeyUp(KeyCode.W)) {
			animator.SetInteger("direction", 6);
		}

		
		if(Input.GetKeyDown(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W)) {
			lastStopped = 0;
			animator.SetInteger("direction", 2);
			if(!Physics.Raycast(new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z), transform.TransformDirection(Vector3.down), out hit, .302f) && lastStopped != 4 || hit.collider.tag != "wall") {
				transform.Translate(-Vector2.up * .302f);
				if(Physics.Raycast(new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z), transform.TransformDirection(Vector3.down), out hit, .302f)) {
					if(hit.collider.tag == "wall") {

						lastStopped = 4;
					}
				}
			}
		}
		if(Input.GetKeyUp(KeyCode.S)) {
			animator.SetInteger("direction", 7);
		}
	}
}
