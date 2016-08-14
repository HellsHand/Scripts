using UnityEngine;
using System.Collections;

public class HideWall : MonoBehaviour {

	public GameObject wall;

	// Use this for initialization
	void Start () {
		wall.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider collided) {
		wall.SetActive(true);
	}
	
	void OnTriggerExit(Collider collided) {
		wall.SetActive(false);
	}
}
