using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public GameObject startButton;
	public GameObject quitButton;
	public AudioClip buttonSound;
	public AudioSource audioSource;
	private GameObject[] balls;
	private float audioLength;
	private bool audioPlaying;
	private float startTime;
	private float endTime;
	private bool changeScene;

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		balls = GameObject.FindGameObjectsWithTag("ball");
		audioLength = buttonSound.length;
		audioPlaying = false;
		changeScene = false;

	}
	
	// Update is called once per frame
	void Update () {

		/*Mobile inputs*/
		if(Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began){
			Debug.Log ("Arroz");
			Ray ray = Camera.main.ScreenPointToRay( Input.GetTouch(0).position );
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit) && hit.transform.gameObject.name == startButton.name){
				if(!audioPlaying){
					audioSource.PlayOneShot(buttonSound);
					startTime = Time.time;
					audioPlaying = true;
				} else {
					if((Time.time - startTime) > audioLength)
						changeScene = true;
				}
				if(changeScene)
					Application.LoadLevel("GameScene");
			} else if(Physics.Raycast(ray, out hit) && hit.transform.gameObject.name == quitButton.name){
				Application.Quit();
			}
		}

		/*Computer inputs*/
		if (Input.GetButtonDown ("Fire1") || audioPlaying) {
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition);
			RaycastHit hit;
			
			if((Physics.Raycast(ray, out hit) && hit.transform.gameObject.name == startButton.name) || audioPlaying){
				if(!audioPlaying){
					audioSource.PlayOneShot(buttonSound);
					startTime = Time.time;
					audioPlaying = true;
				} else {
					if((Time.time - startTime) > audioLength)
						changeScene = true;
				}
				if(changeScene)
					Application.LoadLevel("GameScene");
			} else if(Physics.Raycast(ray, out hit) && hit.transform.gameObject.name == quitButton.name){
				audioSource.PlayOneShot(buttonSound);
				Application.Quit();
			} else {
				foreach(GameObject ball in balls) {
					if(Physics.Raycast(ray, out hit) && hit.transform.gameObject.name == ball.name){
						hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
					}
				}	
			} 
		}
	}


}
