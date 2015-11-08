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
	protected bool isMoving;
	
	public virtual void construct (GameObject gameObject, GameObject explosion){}

	private void desactivateObject() {
	
		GameObject.Destroy(barrel.transform.parent.gameObject);
	}

	public void explodeObject() {
		this.active = false;
		explosion.GetComponent<ParticleSystem> ().enableEmission = true;
		explosion.GetComponent<ParticleSystem> ().Play ();
		// Give the score to the player that is playing
		Debug.Log ("Gosto de arroz no cu");
		GameMaster.getPlayingPlayer().addScore(this.scoreValue);
		Invoke("desactivateObject", 0.8f);
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
		

		if (checkLimit () && this.active) {
			explodeObject();
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

	public bool getIsMoving() {
		return this.isMoving;
	}

	public void setIsMoving(bool isMoving) {
		this.isMoving = isMoving;
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
		GameMaster.barrels.Add (this);
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
		this.forceLimit = 650000.0F;
		this.scoreValue = 15;
		GameMaster.barrels.Add (this);
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
		this.forceLimit = 650000.0F;
		this.scoreValue = 20;
		GameMaster.barrels.Add (this);
	}
	
}
