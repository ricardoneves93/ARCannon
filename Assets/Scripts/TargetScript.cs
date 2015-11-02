using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
	tags: barrel1, barrel2, barrel3
 */

public class TargetScript : MonoBehaviour {
	private List<Barrel> barrels1 = new List<Barrel>();
	private List<Barrel> barrels2 = new List<Barrel>();
	private List<Barrel> barrels3 = new List<Barrel>();

	// Use this for initialization
	void Start () {


		//Get all target objects on scene
		GameObject[] gameBarrels1;
		GameObject[] gameBarrels2;
		GameObject[] gameBarrels3;

		gameBarrels1 = GameObject.FindGameObjectsWithTag("barrel1");
		gameBarrels2 = GameObject.FindGameObjectsWithTag("barrel2");
		gameBarrels3 = GameObject.FindGameObjectsWithTag("barrel3");

		print ("Barrel 1" + gameBarrels1.Length);

		foreach (GameObject barrel1 in gameBarrels1) {
			barrels1.Add(new Barrel(barrel1, 5300.0F));
		}

		foreach (GameObject barrel2 in gameBarrels2) {
			barrels2.Add(new Barrel(barrel2, 10000.0F));
		}

		foreach (GameObject barrel3 in gameBarrels3) {
			barrels3.Add(new Barrel(barrel3, 12000.0F));
		}

	}
	
	// Update is called once per frame
	void Update () {


		// type 1 barrel
		foreach (Barrel barrel1 in barrels1) {
			if(barrel1.getActive()) {
				Rigidbody rb = barrel1.getGameObject().GetComponent<Rigidbody> ();
				float force = 0.5f * rb.mass * Mathf.Pow(rb.velocity.magnitude,2);
				barrel1.addForce(force);
				print ("Accumulator force: " + barrel1.getForceAcc());
				if(!barrel1.checkLimit()) {
					// Deactivate object
					GameObject explosion = barrel1.getGameObject().transform.FindChild("Explosion").gameObject;
					Instantiate(explosion);
					barrel1.getGameObject().SetActive(false);
			}

		}

		// type 2 barrel
		foreach (Barrel barrel2 in barrels2) {
			if(barrel2.getActive()) {
				Rigidbody rb = barrel2.getGameObject().GetComponent<Rigidbody> ();
				float force = 0.5f * rb.mass * Mathf.Pow(rb.velocity.magnitude,2);
				barrel2.addForce(force);
				print ("Accumulator force: " + barrel2.getForceAcc());
				if(!barrel2.checkLimit()) {
					// Deactivate object
					barrel2.getGameObject().SetActive(false);
				}
			}
			
		}

		// type 3 barrel
		foreach (Barrel barrel3 in barrels3) {
			if(barrel3.getActive()) {
				Rigidbody rb = barrel3.getGameObject().GetComponent<Rigidbody> ();
				float force = 0.5f * rb.mass * Mathf.Pow(rb.velocity.magnitude,2);
				barrel3.addForce(force);
				print ("Accumulator force: " + barrel3.getForceAcc());
				if(!barrel3.checkLimit()) {
					// Deactivate object
					barrel3.getGameObject().SetActive(false);
				}
			}
			
		}

	}
}
}



public class Barrel {
	private GameObject barrel;
	private bool active;
	private float forceAcc;
	private float forceLimit;

	public Barrel(GameObject gameObject, float forceLimit) {
		this.barrel = gameObject;
		this.forceAcc = 0.0F;
		this.forceLimit = forceLimit;
		this.active = true;

	}

	public void addForce(float force) {
		this.forceAcc += force;
	}

	public bool checkLimit() {
		if (forceAcc >= forceLimit)
			this.active = false;
		return active;
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

}
