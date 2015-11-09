using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour {
	public static GameMaster GM;

	public static int ballsAllowed = 4;
	public static int currentScene = 0;
	public static int resultPlayer1 = 0;
	public static int resultPlayer2 = 0;
	public static int levelTime = 0;
	public static Text result;
	public static RawImage imageBalls;
	public static string[] scenes;
	public static bool isChangingLevel = false;
	public static List<Barrel> barrels = new List<Barrel> ();
	public static GameObject[] levels;
	public static Texture[] ballsTexture;
	public static RawImage player1Turn;
	public static RawImage player2Turn;
	public static RawImage[] levelsScreens;
	public static RawImage player1Winner;
	public static RawImage player2Winner;
	public static RawImage playersDraw;

	// Create the players
	public static Player player1;
	public static Player player2;
	

	void Awake()
	{
		if(GM != null)
			GameObject.Destroy(GM);
		else
			GM = this;

		player1 = gameObject.AddComponent<Player> () as Player;
		player2 = gameObject.AddComponent<Player> () as Player;
		
		player1.StartPlayer (ballsAllowed, "Player1");
		player2.StartPlayer (ballsAllowed, "Player2");

		DontDestroyOnLoad(this);
	}

	public static void setInitialTurns() {
		player1.setTurn ();
		updateResultText (GameMaster.resultPlayer1, GameMaster.resultPlayer2);
	}
	

	public static Player getPlayingPlayer(){
		if (player1.getIsTurn ())
			return player1;
		return player2;
	}

	public static void changePlayersTurns() {
		if (GameMaster.levelTime == 0) {
			GameMaster.levelTime = 1;
			GameMaster.isChangingLevel = true;
			if(GameMaster.getActiveBarrels () == 0)
				GameMaster.getPlayingPlayer().addScore (GameMaster.getPlayingPlayer().getBallsAvailable() * 10);
			player1.WaitAndThen(0);


		} else {
			GameMaster.levelTime = 0;
			GameMaster.isChangingLevel = true;
			if(GameMaster.getActiveBarrels () == 0)
				GameMaster.getPlayingPlayer().addScore (GameMaster.getPlayingPlayer().getBallsAvailable() * 10);
			if(GameMaster.currentScene < 4)
				GameMaster.currentScene++;
			else {
				// Game ends
				if(GameMaster.resultPlayer1 > GameMaster.resultPlayer2)
					GameMaster.player1.WaitWinnerScreen(0);
				else if(GameMaster.resultPlayer2 > GameMaster.resultPlayer1)
					GameMaster.player1.WaitWinnerScreen(1);
				else if(GameMaster.resultPlayer1 == GameMaster.resultPlayer2)
					GameMaster.player1.WaitWinnerScreen(2);
			}
			player1.WaitAndThen(1);

		}
	}

	public static void ChangeLevelInternal(int mode)
	{
		// reset barrels list
		GameMaster.barrels = new List<Barrel> ();
		// reset Scene
		Destroy (GameObject.FindGameObjectWithTag ("target"));
		Instantiate (levels[GameMaster.currentScene]);
		resetCannon();
		eraseCannonBalls();
		player1.changeTurn ();
		player2.changeTurn ();
		GameMaster.isChangingLevel = false;
		// reset to first balls image
		GameMaster.imageBalls.texture = GameMaster.ballsTexture [4];
		if (mode == 1) {
			updateResultText (GameMaster.player1.getLastScore (), GameMaster.player2.getLastScore ());
		}


	}

	// hides splashscreen
	/*
	public static void hideSplashScreen (){
		GameMaster.levelsScreens[currentScene].enabled = false;
		player1.WaitAndThen(1);
	}
	*/

	// Called everytime player shoots
	public static void RemovePlayerBall(){
		if (player1.getIsTurn ())
			player1.removePlayerBall ();
		else player2.removePlayerBall ();

	}

	public static int getActiveBarrels() {
		int active = 0;
		for (int i = 0; i < GameMaster.barrels.Count; i++) {
			if(GameMaster.barrels[i].getActive())
				active++;
				
		}

		return active;
	}

	public static void updateResultText(int score1, int score2) {
		if (score1 > score2)
			GameMaster.resultPlayer1 ++;
		else if (score2 > score1)
			GameMaster.resultPlayer2 ++;
		else if(GameMaster.currentScene != 0){
			GameMaster.resultPlayer1 ++;
			GameMaster.resultPlayer2 ++;
		}

		GameMaster.result.text = resultPlayer1.ToString () + "-" + resultPlayer2.ToString ();
	}

	public static bool nothingMoving(){
		for (int i = 0; i < GameMaster.barrels.Count; i++) {
			if(GameMaster.barrels[i].getActive()){
				if(GameMaster.barrels[i].getIsMoving()){
					return false;
				}
			}
		}

		return true;
	}

	public static bool noBalls() {
		GameObject[] balls = GameObject.FindGameObjectsWithTag ("cannonBall");

		for (int i = 0; i < balls.Length ; i++) {
			if(!balls[i].GetComponent<Rigidbody>().IsSleeping())
				return false;
		}
		return true;
	}

	private static void resetCannon() {
		GameObject cannon = GameObject.FindGameObjectWithTag ("cannon");
		cannon.transform.localRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
		GameObject barrel = cannon.transform.FindChild ("father_barrel").gameObject;
		barrel.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
	}

	private static void eraseCannonBalls() {
		Destroy(GameObject.FindGameObjectWithTag("cannonBall"));
	}

}

