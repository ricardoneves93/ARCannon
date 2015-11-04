using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainScript : MonoBehaviour {

	public Text score1, score2;
	public Text player1, player2;
	public Text balls1, balls2;

	string[] scenes = {"GameScene", "GameScene1", "GameScene2", "GameScene3", "GameScene4"};

	// Use this for initialization
	void Start () {

		//Application.LoadLevel("GameScene");

		GameMaster.player1.setLabels (score1, player1, balls1);
		GameMaster.player2.setLabels (score2, player2, balls2);

		// set players turns
		GameMaster.setInitialTurns ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
