#pragma strict

var damage : int = 50;
var distance : float;
var maxDistance : float = 1.5;
var theMace : Transform;

function Update() {
	if(Input.GetButtonDown("Fire1")) {	
		theMace.animation.Play("attack");
		var hit : RaycastHit;
		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), hit)) {
			distance = hit.distance;
			if(distance < maxDistance) {
				hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
	if(!theMace.animation.isPlaying) {
		theMace.animation.CrossFade("idle");
	}
	if(Input.GetKey(KeyCode.LeftShift)) {
		theMace.animation.CrossFade("run");
	}
	if(Input.GetKeyUp(KeyCode.LeftShift)) {
		theMace.animation.CrossFade("idle");
	}
}