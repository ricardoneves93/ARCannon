using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour {
	public static GameMaster GM;

	public static int ballsAllowed = 4;
	public static int currentScene = 0;
	public static int resultPlayer1 = 0;
	public static int resultPlayer2 = 0;
	public static Text result;
	public static string[] scenes;
	public static List<Barrel> barrels = new List<Barrel> ();

	// Create the players
	public static Player player1 = new Player(ballsAllowed, "Ricardo");
	public static Player player2 = new Player(ballsAllowed, "Daniel");
	

	void Awake()
	{

		if(GM != null)
			GameObject.Destroy(GM);
		else
			GM = this;
		
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

	private static void changePlayersTurns() {
		player1.changeTurn ();
		player2.changeTurn ();
		updateResultText (GameMaster.player1.getScore (), GameMaster.player2.getScore ());
	}

	// Called everytime player shoots
	public static void RemovePlayerBall(){
		if (player1.getIsTurn ()) {
			player1.removePlayerBall ();
			if (player1.getBallsAvailable () == 0) {
				// change turns
				GameMaster.changePlayersTurns ();
				// reset barrels list
				GameMaster.barrels = new List<Barrel> ();
				// reset Scene
				Destroy(GameObject.FindGameObjectWithTag("target"));
				Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/" + GameMaster.scenes[GameMaster.currentScene]+ ".prefab", typeof(GameObject)));

			} else if( GameMaster.getActiveBarrels() == 0){
				// change turns
				GameMaster.changePlayersTurns ();
				// reset barrels list
				GameMaster.barrels = new List<Barrel> ();
				// reset Scene
				Destroy(GameObject.FindGameObjectWithTag("target"));
				Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/" + GameMaster.scenes[GameMaster.currentScene]+ ".prefab", typeof(GameObject)));
			}
		} else if (player2.getIsTurn ()) {
			player2.removePlayerBall ();
			if (player2.getBallsAvailable () == 0) {
				// update result variables
				if(GameMaster.player1.getScore() > GameMaster.player2.getScore())
					GameMaster.resultPlayer1++;
				else if(GameMaster.player2.getScore() > GameMaster.player1.getScore())
					GameMaster.resultPlayer2++;
				else {
					GameMaster.resultPlayer1++;
					GameMaster.resultPlayer2++;
				}
				// change turns
				GameMaster.changePlayersTurns ();
				// reset barrels list
				GameMaster.barrels = new List<Barrel> ();
				// Change to next scene
				if(GameMaster.currentScene < 4){
					GameMaster.currentScene++;
					Destroy(GameObject.FindGameObjectWithTag("target"));
					Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/" + GameMaster.scenes[GameMaster.currentScene]+ ".prefab", typeof(GameObject)));

				} else {
					// Anounce the winner
				}


			} else if( GameMaster.getActiveBarrels() == 0){
				GameMaster.currentScene++;
				Destroy(GameObject.FindGameObjectWithTag("target"));
				Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/" + GameMaster.scenes[GameMaster.currentScene]+ ".prefab", typeof(GameObject)));
				GameMaster.changePlayersTurns ();
			}
		}
	}

	public static int getActiveBarrels() {
		int active = 0;
		for (int i = 0; i < GameMaster.barrels.Count; i++) {
			if(GameMaster.barrels[i].getActive())
				active++;
				
		}

		return active;
	}

	private static void updateResultText(int score1, int score2) {
		GameMaster.result.text = resultPlayer1.ToString () + "-" + resultPlayer2.ToString ();
	}
}

