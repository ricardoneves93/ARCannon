using UnityEngine;
using System.Collections;

public class HardBarrelScript : MonoBehaviour {

	private Hard barrel;

	// Use this for initialization
	void Start () {
		GameObject explosion = this.gameObject.transform.parent.FindChild ("Explosion").gameObject;
		barrel = new Hard (this.gameObject, explosion);
		//GameMaster.barrels.Add(barrel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		GameObject collidedWith = col.gameObject;
		barrel.addForce (collidedWith);
	}

}
