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
	public static int levelTime = 0;
	public static Text result;
	public static string[] scenes;
	public static bool isChangingLevel = false;
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

	public static void changePlayersTurns() {
		player1.changeTurn ();
		player2.changeTurn ();
		if (GameMaster.levelTime == 0) {
			Debug.Log ("Pilas0");
			GameMaster.levelTime = 1;
			// reset barrels list
			GameMaster.barrels = new List<Barrel> ();
			// reset Scene
			Destroy (GameObject.FindGameObjectWithTag ("target"));
			GameMaster.isChangingLevel = true;
			Instantiate (AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/" + GameMaster.scenes [GameMaster.currentScene] + ".prefab", typeof(GameObject)));
			GameMaster.isChangingLevel = false;
		} else {
			Debug.Log("Pilas1");
			GameMaster.currentScene++;
			GameMaster.levelTime = 0;
			// reset barrels list
			GameMaster.barrels = new List<Barrel> ();
			// reset Scene
			Destroy(GameObject.FindGameObjectWithTag("target"));
			GameMaster.isChangingLevel = true;
			Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/" + GameMaster.scenes[GameMaster.currentScene]+ ".prefab", typeof(GameObject)));
			GameMaster.isChangingLevel = false;
		}
			
		
		updateResultText (GameMaster.player1.getScore (), GameMaster.player2.getScore ());
	}

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

	private static void updateResultText(int score1, int score2) {
		GameMaster.result.text = resultPlayer1.ToString () + "-" + resultPlayer2.ToString ();
	}

	public static bool nothingMoving(){
		for (int i = 0; i < GameMaster.barrels.Count; i++) {
			if(GameMaster.barrels[i].getActive()){
				if(GameMaster.barrels[i].getIsMoving()){
					Debug.Log("Moving object" + GameMaster.barrels[i].gameObject.name);
					return false;
				}
			}
		}
		return true;
	}

}

