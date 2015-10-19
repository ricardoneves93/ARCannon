#pragma strict

var cannonball : GameObject;
var barrel : GameObject;
var endPiece : GameObject;
var rateOfFire: float = 0.5;
internal var fireDelay : float;
var speed : float = 20;

function Start () {
}

function Update () {

	if(Input.GetButtonDown("Fire1")) {
		
		fireDelay = Time.time + rateOfFire;

		var clone : GameObject = Instantiate(cannonball, Vector3(endPiece.transform.position.x, endPiece.transform.position.y, endPiece.transform.position.z), cannonball.transform.rotation);

		print("Cos " + Mathf.Cos(barrel.transform.rotation.eulerAngles.x * Mathf.Deg2Rad));
		print("Sin " + Mathf.Sin(barrel.transform.rotation.eulerAngles.x * Mathf.Deg2Rad));
		clone.GetComponent.<Rigidbody>().velocity = Vector3(Mathf.Cos(barrel.transform.rotation.eulerAngles.x * Mathf.Deg2Rad) * speed, - Mathf.Sin(barrel.transform.rotation.eulerAngles.x * Mathf.Deg2Rad)* speed, 0);
	}
	
	var rotation:float = Input.GetAxis("Vertical");
	
	if(barrel.transform.localEulerAngles.x < 315 && barrel.transform.localEulerAngles.x >= 310)
		barrel.transform.localEulerAngles.x = 315;
	
	
	if(barrel.transform.localEulerAngles.x >= 0 && barrel.transform.localEulerAngles.x <= 5)
		barrel.transform.localEulerAngles.x = 0;
	
	
	if(barrel.transform.localEulerAngles.x == 0 || (barrel.transform.localEulerAngles.x >= 315 && barrel.transform.localEulerAngles.x <= 360)) {
		barrel.transform.Rotate(Vector3(-rotation, 0, 0));
	}
}