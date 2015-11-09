using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class Player : MonoBehaviour {
	private int[] score = new int[5];
	private string playerName;
	private bool isWinner;
	private bool isTurn;
	private int[] ballsAvailable = new int[5];
	public Text scoreText;
	public Text nameText;

	public void StartPlayer(int ballsAvailable, string name){

		for (int i = 0; i < score.Length; i++)
			score [i] = 0;

		for (int i = 0; i < this.ballsAvailable.Length; i++)
			this.ballsAvailable [i] = ballsAvailable;

		this.isWinner = false;
		this.playerName = name;
	}

	public void addScore(int score){
		this.score[GameMaster.currentScene] += score;
		this.scoreText.text = "Score: " + this.score[GameMaster.currentScene].ToString ();
	}

	public void changeTurn(){
		if (this.isTurn) {
			this.scoreText.enabled = false;
			this.nameText.enabled = false;
		} else {
			this.scoreText.enabled = true;
			this.nameText.enabled = true;
		}

		this.scoreText.text = "Score: 0";

		this.isTurn = !this.isTurn;
	}

	public void removePlayerBall() {
		this.ballsAvailable[GameMaster.currentScene]--;

		GameMaster.imageBalls.texture = GameMaster.ballsTexture[this.ballsAvailable[GameMaster.currentScene]];

	}


	/*Setters*/
	public void setTurn(){
		this.isTurn = true;
		this.scoreText.enabled = true;
		this.nameText.enabled = true;
		//this.ballsText.enabled = true;
	}

	public void setWinner(){
		this.isWinner = true;
	}

	public void setLabels(Text scoreText, Text nameText){
		this.scoreText = scoreText;
		this.nameText = nameText;

		this.scoreText.text = "Score: " + score[GameMaster.currentScene].ToString ();
		this.nameText.text = playerName;

		this.scoreText.enabled = false;
		this.nameText.enabled = false;
	}


	/*Getters*/
	public int getScore() {
		return this.score[GameMaster.currentScene];
	}

	public int getLastScore(){
		if (GameMaster.currentScene <= 0)
			return 0;
		return this.score[GameMaster.currentScene - 1];
	}

	public bool getIsWinner() {
		return this.isWinner;
	}

	public bool getIsTurn() {
		return this.isTurn;
	}

	public int getBallsAvailable() {
		return this.ballsAvailable[GameMaster.currentScene];
	}

	public void WaitAndThen(int mode) {
		StartCoroutine (AndThen (mode));
	}

	private IEnumerator AndThen(int mode) {

		if (mode == 0 || mode == 3)
			GameMaster.player2Turn.enabled = true;
		else if (mode == 1) {
			WaitSplash (1);
		} else if (mode == 2 || mode == 4) {
			GameMaster.player1Turn.enabled = true;
		}

		yield return new WaitForSeconds (2f);

		if (mode == 0) {
			GameMaster.ChangeLevelInternal (mode);
			GameMaster.player2Turn.enabled = false;
		} else if (mode == 2) {
			GameMaster.ChangeLevelInternal (mode);
			GameMaster.player1Turn.enabled = false;
		} else if (mode == 3) {
			GameMaster.player2Turn.enabled = false;
		} else if (mode == 4) {
			GameMaster.player1Turn.enabled = false;
		}


	}

	public void WaitSplash(int mode) {
		StartCoroutine (AndThen1 (mode));
	}
	
	private IEnumerator AndThen1(int mode) {

		GameMaster.updateResultText (GameMaster.player1.getLastScore (), GameMaster.player2.getLastScore ());

		GameMaster.levelsScreens[GameMaster.currentScene].enabled = true;

		yield return new WaitForSeconds (2f);

		GameMaster.levelsScreens[GameMaster.currentScene].enabled = false;

		if (mode == 1) {
			WaitAndThen (2);
		} else {
			WaitAndThen (4);
		}


	}

	public void WaitWinnerScreen(int winner) {
		StartCoroutine (AndThenWinnerScreen (winner));
	}

	private IEnumerator AndThenWinnerScreen(int winner){

		// Show winner screen
		switch (winner) {

		//  winner is player1
		case 0:
			GameMaster.player1Winner.enabled = true;
			break;
		//  winner is player2
		case 1:
			GameMaster.player2Winner.enabled = true;
			break;
		//  draw
		case 2:
			GameMaster.playersDraw.enabled = true;
			break;
		default:
			break;
		}

			yield return new WaitForSeconds (3f);
		switch (winner) {
		//  winner is player1
		case 0:
			GameMaster.player1Winner.enabled = false;
			break;
		//  winner is player2
		case 1:
			GameMaster.player2Winner.enabled = false;
			break;
		//  draw
		case 2:
			GameMaster.playersDraw.enabled = false;
			break;
		default:
			break;
		}

			Application.LoadLevel("MenuScene");
		
	
	}
}
