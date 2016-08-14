using UnityEngine;
using System.Collections;

public class HideBackground : MonoBehaviour {
	public GameObject background;
	// Use this for initialization
	void Start () {
		background.SetActive(false);
	}

}
