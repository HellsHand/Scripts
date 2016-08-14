using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
	private Animator animator;
	public float speed = 2.5f;
	private int lastKey = 0;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.D)) {
			animator.SetInteger("direction", 3);
			transform.Translate (-Vector2.right * Time.deltaTime * speed);
			lastKey = 3;
		}
		else if (Input.GetKeyUp(KeyCode.A)) {
			animator.SetInteger("direction", 4);

		}
		if (Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.A)) {
			animator.SetInteger("direction", 1);
			transform.Translate (Vector2.right * Time.deltaTime * speed);
			lastKey = 1;
		}
		else if (Input.GetKeyUp(KeyCode.D)) {
			animator.SetInteger("direction", 5);
			
		}
		if (Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.S)) {
			animator.SetInteger("direction", 0);
			transform.Translate (Vector2.up * Time.deltaTime * speed);
			lastKey = 0;
		}
		else if (Input.GetKeyUp(KeyCode.W)) {
			animator.SetInteger("direction", 6);
			
		}
		if (Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.W)) {
			animator.SetInteger("direction", 2);
			transform.Translate (-Vector2.up * Time.deltaTime * speed);
			lastKey = 2;
		}
		else if (Input.GetKeyUp(KeyCode.S)) {
			animator.SetInteger("direction", 7);
			
		}
		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) {
			transform.Translate(Vector2.zero);
			if(lastKey == 3) {
				animator.SetInteger("direction", 4);
			}
			else if(lastKey == 1) {
				animator.SetInteger("direction", 5);
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
		if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) {
			transform.Translate(Vector2.zero);
			if(lastKey == 0) {
				animator.SetInteger("direction", 6);
			}
			else if(lastKey == 2) {
				animator.SetInteger("direction", 7);
			}
		}
	}
}
