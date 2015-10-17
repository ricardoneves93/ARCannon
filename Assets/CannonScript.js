#pragma strict

var cannonball : GameObject;
var barrel : GameObject;
var rateOfFire: float = 0.5;
internal var fireDelay : float;
var speed : float = 20;

function Start () {

}

function Update () {

	if(Input.GetButton("Fire1") && Time.time > fireDelay) {
		fireDelay = Time.time + rateOfFire;
		var clone : GameObject = Instantiate(cannonball, Vector3(-0.43, 3.28, -0.63), cannonball.transform.rotation);
		// Get barrel rotation
		var x: float = barrel.transform.rotation.eulerAngles.x;
		var y : float = barrel.transform.rotation.eulerAngles.y;
		var z : float = barrel.transform.rotation.eulerAngles.z;
		print("X " + x);
		print("Y " + y);
		print("Z " + z);
		clone.GetComponent.<Rigidbody>().velocity = Vector3(speed, speed, 0);
	}
}