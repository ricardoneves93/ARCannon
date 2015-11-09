using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class MainScript : MonoBehaviour {

	public Text score1, score2;
	public Text player1, player2;
	public Text result;
	public RawImage imageBalls;
	public GameObject[] levels;
	public Texture[] ballsTexture;
	public RawImage player1Turn;
	public RawImage player2Turn;
	public RawImage[] levelsScreens;
	public RawImage player1Winner;
	public RawImage player2Winner;
	public RawImage playersDraw;


	string[] scenes = {"Level1", "Level2", "Level3", "Level4", "Level5"};

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<GameMaster> ();

		GameMaster.player1Turn = this.player1Turn;
		GameMaster.player2Turn = this.player2Turn;
		GameMaster.player1Winner = this.player1Winner;
		GameMaster.player2Winner = this.player2Winner;
		GameMaster.playersDraw = this.playersDraw;
		GameMaster.levelsScreens = this.levelsScreens;
		GameMaster.result = this.result;
		GameMaster.scenes = this.scenes;
		GameMaster.levels = this.levels;
		GameMaster.ballsTexture = this.ballsTexture;
		GameMaster.imageBalls = this.imageBalls;
		GameMaster.player1.setLabels (score1, player1);
		GameMaster.player2.setLabels (score2, player2);
		
		// set players turns
		GameMaster.setInitialTurns ();
		
		GameMaster.player1.WaitSplash (0);

	}
	
	// Update is called once per frame
	void Update () {
		Player player;

		if (GameMaster.player1.getIsTurn ())
			player = GameMaster.player1;
		else
			player = GameMaster.player2;



		if (GameMaster.currentScene <= 4) {
			// If no balls available
			if (player.getBallsAvailable () == 0 && !GameMaster.isChangingLevel) {
				if (GameMaster.nothingMoving () && GameMaster.noBalls ()) {
					GameMaster.changePlayersTurns ();
				}
			} else if (GameMaster.getActiveBarrels () == 0 && !GameMaster.isChangingLevel) {
				if (GameMaster.nothingMoving ()){
					GameMaster.changePlayersTurns ();
				}
			}
		}

	}
}
