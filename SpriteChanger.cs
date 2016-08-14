using UnityEngine;
using System.Collections;

public class SpriteChanger : MonoBehaviour {

	public Sprite[] sprite001 = new Sprite[4];


	// Use this for initialization
	void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent <SpriteRenderer>().sprite = sprite001[0];
		if (Input.GetKey(KeyCode.D)) {
			GetComponent <SpriteRenderer>().sprite = sprite001[1];
		}
	}
}
