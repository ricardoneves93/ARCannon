using UnityEngine;
using System.Collections;

public class CannonBallScript : MonoBehaviour {
	
	private AudioSource[] sounds;


	void Start(){
		sounds = GetComponents<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 5);

		if (this.transform.position.y < GameObject.Find ("MainPlane").transform.position.y)
			Destroy (gameObject);
		
	}

	void OnCollisionEnter (Collision col){
		
		if (col.gameObject.CompareTag ("barrel"))
			sounds[0].Play();

		if (col.gameObject.CompareTag ("barrel"))
			sounds [1].Play ();

		if (col.gameObject.CompareTag ("floor"))
			sounds [2].Play ();
		
	}

}
