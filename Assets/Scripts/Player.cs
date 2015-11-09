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
		Debug.Log ("Pilas gordas: " + GameMaster.currentScene);
		return this.ballsAvailable[GameMaster.currentScene];
	}

	public void WaitAndThen()
	{
		StartCoroutine (AndThen ());
	}

	IEnumerator AndThen()
	{
		yield return new WaitForSeconds (5f);

		GameMaster.ChangeLevelInternal ();
	}
}
