#pragma strict

function Update () {
	if(Input.GetKey(KeyCode.E)) {
		animation.Play("Default Take");
	}
	else if(Input.GetKey(KeyCode.R)) {
		animation.Play("Poses");
	}
}