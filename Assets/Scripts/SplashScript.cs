using UnityEngine;
using System.Collections;

public class SplashScript : MonoBehaviour {

	private float startTime = Time.time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.time - startTime > 2.0f)
			Application.LoadLevel("MenuScene");
	}
}
