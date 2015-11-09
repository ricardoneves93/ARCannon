using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public AudioClip buttonSound;
	public AudioSource audioSource;

	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void OnPlayBtnPress()
	{
		audioSource.PlayOneShot(buttonSound);
		Invoke ("ChangeScene", 1f);
	}

	public void OnExitBtnPress()
	{
		Application.Quit();
	}

	private void ChangeScene()
	{
		Application.LoadLevel("GameScene");
	}
}
