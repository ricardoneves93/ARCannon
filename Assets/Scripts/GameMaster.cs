using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour {
	public static GameMaster GM;

	public static int ballsAllowed = 4;
	public static int currentScene = 0;


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
	}
	

	public static Player getPlayingPlayer(){
		if (player1.getIsTurn ())
			return player1;
		return player2;
	}

	private static void changePlayersTurns() {
		player1.changeTurn ();
		player2.changeTurn ();
	}

	public static void RemovePlayerBall(){
		if (player1.getIsTurn ()) {
			player1.removePlayerBall ();
			if (player1.getBallsAvailable () == 0) {
				GameMaster.changePlayersTurns ();
				// Reset Scene

			} //else if( no more barrels)
		} else if (player2.getIsTurn ()) {
			player2.removePlayerBall ();
			if (player2.getBallsAvailable () == 0) {
				GameMaster.changePlayersTurns ();
				// Reset Scene

			} //else if(no more barrels)
		}
	}
}

