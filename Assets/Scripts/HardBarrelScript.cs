using UnityEngine;
using System.Collections;

public class HardBarrelScript : MonoBehaviour {

	private Hard barrel;
	private AudioSource[] sounds;

	// Use this for initialization
	void Start () {
		GameObject explosion = this.gameObject.transform.FindChild ("Explosion").gameObject;
		barrel = this.gameObject.AddComponent<Hard>() as Hard;
		sounds = GetComponents<AudioSource> ();
		barrel.construct (this.gameObject, explosion, sounds[1]);
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

		if (col.gameObject.CompareTag ("barrel") && (GameMaster.getPlayingPlayer().getBallsAvailable() != 4))
			sounds [2].Play ();
		
		if (col.gameObject.CompareTag ("floor"))
			sounds [0].Play ();
	}

}
