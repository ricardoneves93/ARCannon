using UnityEngine;
using System.Collections;

/*Abstract class that will hold the generic Barrel object*/
public abstract class Barrel {
	protected GameObject barrel;
	protected GameObject explosion;
	protected bool active;
	protected float forceAcc;
	protected float forceLimit;
	protected bool played;
	
	
	public Barrel(GameObject gameObject, GameObject explosion) {
		this.barrel = gameObject;
		this.explosion = explosion;
		this.forceAcc = 0.0F;
		this.active = true;
		this.played = false;
		
	}
	
	public void addForce(GameObject collidedWith) {
		// Force calculations
								// Velocity of the barrel						// Velocity of the object that collided
		float impactVelocityX = barrel.GetComponent<Rigidbody>().velocity.x - collidedWith.GetComponent<Rigidbody>().velocity.x;
		impactVelocityX *= Mathf.Sign (impactVelocityX);

								// Velocity of the barrel						// Velocity of the object that collided
		float impactVelocityY = barrel.GetComponent<Rigidbody>().velocity.y  - collidedWith.GetComponent<Rigidbody>().velocity.y;
		impactVelocityY *= Mathf.Sign (impactVelocityY);

								// Velocity of the barrel						// Velocity of the object that collided
		float impactVelocityZ = barrel.GetComponent<Rigidbody>().velocity.z - collidedWith.GetComponent<Rigidbody>().velocity.z;
		impactVelocityZ *= Mathf.Sign (impactVelocityZ);

		float impactVelocity = impactVelocityX + impactVelocityY + impactVelocityZ;

		float impactForce = impactVelocity * barrel.GetComponent<Rigidbody>().mass * collidedWith.GetComponent<Rigidbody>().mass;

		impactForce *= Mathf.Sign (impactForce);

		this.forceAcc += impactForce;

		Debug.Log("Impact force " + this.forceAcc);

		if (checkLimit ()) {
			explosion.GetComponent<ParticleSystem> ().enableEmission = true;
			explosion.GetComponent<ParticleSystem> ().Play ();
			barrel.SetActive (false);

			// Add timeout when animation ends to destroy gameObject
			//GameObject.Destroy(barrel.transform.parent.gameObject);
		}

	}
	
	public bool checkLimit() {
		return (forceAcc >= forceLimit);
	}
	
	public GameObject getGameObject() {
		return this.barrel;
	}
	
	public float getForceAcc() {
		return this.forceAcc;
	}
	
	public bool getActive() {
		return this.active;
	}
	
	public void setActive(bool active) {
		this.active = active;
	}
	
	public bool getPlayed(){
		return this.played;
	}
	
	public void setPlayed(bool played) {
		this.played = played;
	}
	
	
}


public class Easy : Barrel {
	
	/*calls allways parent constructor*/
	public Easy(GameObject gameObject, GameObject explosion) : base(gameObject, explosion) {
		this.forceLimit = 650000.0F;
	}
	
}

public class Medium : Barrel {
	
	/*calls allways parent constructor*/
	public Medium(GameObject gameObject, GameObject explosion) : base(gameObject, explosion) {
		this.forceLimit = 700000.0F;
	}
	
}

public class Hard : Barrel {
	
	/*calls allways parent constructor*/
	public Hard(GameObject gameObject, GameObject explosion) : base(gameObject, explosion) {
		this.forceLimit = 800000.0F;
	}
	
}
