#pragma strict

var health : int = 100;

function Update() {
	if(health <= 0) {
		Death();
	}
}

function ApplyDamage(damage : int) {
	health -= damage;
}

function Death() {
	Destroy(gameObject);
}