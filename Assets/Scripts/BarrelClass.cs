using UnityEngine;
using System.Collections;

/*Abstract class that will hold the generic Barrel object*/
public abstract class Barrel : MonoBehaviour{
	protected GameObject barrel;
	protected GameObject explosion;
	protected bool active;
	protected float forceAcc;
	protected float forceLimit;
	protected int scoreValue;
	protected bool played;
	
	public virtual void construct (GameObject gameObject, GameObject explosion){}

	public void desactivateObject() {

		barrel.SetActive (false);
		GameObject.Destroy(barrel.transform.parent.gameObject);
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

			// Give the score to the player that is playing
			GameMaster.getPlayingPlayer().addScore(this.scoreValue);
			Invoke("desactivateObject", 0.8f);


			//StartCoroutine(desactivateObject());
			//barrel.SetActive (false);

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
	public override void construct(GameObject gameObject, GameObject explosion){
		this.barrel = gameObject;
		this.explosion = explosion;
		this.forceAcc = 0.0F;
		this.active = true;
		this.played = false;
		this.forceLimit = 650000.0F;
		this.scoreValue = 10;
	}
	
}

public class Medium : Barrel {
	
	/*calls allways parent constructor*/
	public override void construct(GameObject gameObject, GameObject explosion) {
		this.barrel = gameObject;
		this.explosion = explosion;
		this.forceAcc = 0.0F;
		this.active = true;
		this.played = false;
		this.forceLimit = 700000.0F;
		this.scoreValue = 15;
	}
	
}

public class Hard : Barrel {
	
	/*calls allways parent constructor*/
	public override void construct(GameObject gameObject, GameObject explosion) {
		this.barrel = gameObject;
		this.explosion = explosion;
		this.forceAcc = 0.0F;
		this.active = true;
		this.played = false;
		this.forceLimit = 800000.0F;
		this.scoreValue = 20;
	}
	
}
