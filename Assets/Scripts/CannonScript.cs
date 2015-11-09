using UnityEngine;
using System.Collections;
using CnControls;

public class CannonScript : MonoBehaviour {
	
	public GameObject cannonBall;
	public GameObject barrel;
	public GameObject endPiece;
	public GameObject aim;
	public float rateOfFire;
	private float fireDelay;
	private int speed;
	private float horizontalRotationSpeed;
	
	
	void Start() {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		rateOfFire = 0.5F;
		speed = 15;
		fireDelay = 0.0F;
		horizontalRotationSpeed = 0.5F;
		barrel.transform.localEulerAngles = new Vector3(0, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);
	}
	
	
	void Update() {

		// Fire cannon
		if(CnInputManager.GetButton("Jump") && Time.time > fireDelay) {

			if(GameMaster.getPlayingPlayer().getBallsAvailable() > 0 && !GameMaster.isChangingLevel){
				fireDelay = Time.time + rateOfFire;
				
				GameObject clone = (GameObject) Instantiate(cannonBall, new Vector3(endPiece.transform.position.x, endPiece.transform.position.y, endPiece.transform.position.z), cannonBall.transform.rotation);
				
				
				Vector3 dir = aim.transform.forward;
				Rigidbody rb = clone.GetComponent<Rigidbody>();
				rb.velocity = new Vector3(dir.x * speed, dir.y * speed, dir.z * speed);

				GetComponent<AudioSource>().Play();
				
				// Removes a ball from player that is playing
				GameMaster.RemovePlayerBall();
			}
			
		}

		// Computer controls
		float verticalRotation = Input.GetAxis("Vertical");

		if (!GameMaster.isChangingLevel) {
			if(barrel.transform.localEulerAngles.x < 315 && barrel.transform.localEulerAngles.x >= 310)
				barrel.transform.localEulerAngles = new Vector3(315, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);
			
			
			if(barrel.transform.localEulerAngles.x >= 0 && barrel.transform.localEulerAngles.x <= 5)
				barrel.transform.localEulerAngles = new Vector3(0, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);
			
			
			if(barrel.transform.localEulerAngles.x == 0 || (barrel.transform.localEulerAngles.x >= 315 && barrel.transform.localEulerAngles.x <= 360)) {
				barrel.transform.Rotate(new Vector3(-verticalRotation, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z));
			}
		}



		if (!GameMaster.isChangingLevel) {
			/* Mobile controls */
			float verticalMobileRotation = CnInputManager.GetAxis ("Vertical");
			
			if(barrel.transform.localEulerAngles.x < 315 && barrel.transform.localEulerAngles.x >= 310)
				barrel.transform.localEulerAngles = new Vector3(315, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);
			
			
			if(barrel.transform.localEulerAngles.x >= 0 && barrel.transform.localEulerAngles.x <= 5)
				barrel.transform.localEulerAngles = new Vector3(0, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z);
			
			
			if(barrel.transform.localEulerAngles.x == 0 || (barrel.transform.localEulerAngles.x >= 315 && barrel.transform.localEulerAngles.x <= 360)) {
				barrel.transform.Rotate(new Vector3(-verticalMobileRotation, barrel.transform.localEulerAngles.y, barrel.transform.localEulerAngles.z));
			}
			
			
			float horizontalMobileRotation = CnInputManager.GetAxis ("Horizontal");
			
			transform.Rotate(new Vector3(transform.localEulerAngles.x, horizontalMobileRotation *  horizontalRotationSpeed, transform.localEulerAngles.z));
		}



		
	}
	
	
}