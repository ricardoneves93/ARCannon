using UnityEngine;
using System.Collections;

public class CannonBallScript : MonoBehaviour {
	

	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 5);

		if (this.transform.position.y < GameObject.Find ("MainPlane").transform.position.y)
			Destroy (gameObject);
	}

}
