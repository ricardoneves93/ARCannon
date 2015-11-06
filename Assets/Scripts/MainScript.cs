using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainScript : MonoBehaviour {

	public Text score1, score2;
	public Text player1, player2;
	public Text result;

	string[] scenes = {"Level1", "Level2", "Level3", "Level4", "Level5"};

	// Use this for initialization
	void Start () {

		//Application.LoadLevel("GameScene");
		GameMaster.result = this.result;
		GameMaster.scenes = this.scenes;
		GameMaster.player1.setLabels (score1, player1);
		GameMaster.player2.setLabels (score2, player2);

		// set players turns
		GameMaster.setInitialTurns ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
