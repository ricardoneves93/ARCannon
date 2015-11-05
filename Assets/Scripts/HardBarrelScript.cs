using UnityEngine;
using System.Collections;

public class HardBarrelScript : MonoBehaviour {

	private Hard barrel;

	// Use this for initialization
	void Start () {
		GameObject explosion = this.gameObject.transform.FindChild ("Explosion").gameObject;
		barrel = this.gameObject.AddComponent<Hard>() as Hard;
		barrel.construct (this.gameObject, explosion);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		GameObject collidedWith = col.gameObject;
		barrel.addForce (collidedWith);
	}

}
