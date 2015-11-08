using UnityEngine;
using System.Collections;

public class MediumBarrelScript : MonoBehaviour {

	private Medium barrel;

	// Use this for initialization
	void Start () {
		GameObject explosion = this.gameObject.transform.FindChild ("Explosion").gameObject;
		barrel = this.gameObject.AddComponent<Medium>() as Medium;
		barrel.construct (this.gameObject, explosion);
	}
	
	// Update is called once per frame
	void Update () {
		barrel.setIsMoving(!this.GetComponent<Rigidbody> ().IsSleeping ());

		if ((this.transform.position.y < GameObject.Find ("MainPlane").transform.position.y) && barrel.getActive()) {
			barrel.explodeObject ();
		}
	}

	void OnCollisionEnter(Collision col){
		GameObject collidedWith = col.gameObject;
		barrel.addForce (collidedWith);
	}
}
