#pragma strict

var cannonball : GameObject;
var barrel : GameObject;
var rateOfFire: float = 0.5;
internal var fireDelay : float;
var speed : float = 100;

function Start () {
}

function Update () {

	if(Input.GetButtonDown("Fire1")) {
		
		fireDelay = Time.time + rateOfFire;
		//print("Time: " + Time.time);
		//print("Fire delay: " + fireDelay);
		var clone : GameObject = Instantiate(cannonball, Vector3(-0.68, 2.773861, -0.6961163), cannonball.transform.rotation);
		// Get barrel rotation
		//var x: float = barrel.transform.rotation.eulerAngles.x;
		//var y : float = barrel.transform.rotation.eulerAngles.y;
		//var z : float = barrel.transform.rotation.eulerAngles.z;
		//print("X " + x);
		//print("Y " + y);
		//print("Z " + z);
		//print("FIRE!");
		clone.GetComponent.<Rigidbody>().velocity = Vector3(speed*2, speed/2, 0);
	}
}