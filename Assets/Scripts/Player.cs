using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player {
	private int[] score = new int[5];
	private string name;
	private bool isWinner;
	private bool isTurn;
	private int ballsAvailable;
	public Text scoreText;
	public Text nameText;
	public Text ballsText;

	public Player(int ballsAvailable, string name){

		for (int i = 0; i < score.Length; i++)
			score [i] = 0;

		this.isWinner = false;
		this.name = name;
		this.ballsAvailable = ballsAvailable;
	}

	public void addScore(int score){
		this.score[GameMaster.currentScene] += this.score[GameMaster.currentScene];
		this.scoreText.text = "Score: " + score.ToString ();
	}

	public void changeTurn(){
		if (this.isTurn) {
			this.scoreText.enabled = false;
			this.nameText.enabled = false;
			this.ballsText.enabled = false;
		} else {
			this.scoreText.enabled = true;
			this.nameText.enabled = true;
			this.ballsText.enabled = true;
		}

		this.isTurn = !this.isTurn;
	}

	public void removePlayerBall() {
		this.ballsAvailable--;
		this.ballsText.text = "Balls left: " + ballsAvailable.ToString ();
	}


	/*Setters*/
	public void setTurn(){
		this.isTurn = true;
		this.scoreText.enabled = true;
		this.nameText.enabled = true;
		this.ballsText.enabled = true;
	}

	public void setWinner(){
		this.isWinner = true;
	}

	public void setLabels(Text scoreText, Text nameText, Text ballsText){
		this.scoreText = scoreText;
		this.nameText = nameText;
		this.ballsText = ballsText;

		this.scoreText.text = "Score: " + score.ToString ();
		this.nameText.text = name;
		this.ballsText.text = "Balls left: " + ballsAvailable.ToString();

		this.scoreText.enabled = false;
		this.nameText.enabled = false;
		this.ballsText.enabled = false;
	}


	/*Getters*/
	public int getScore() {
		return this.score[GameMaster.currentScene];
	}

	public bool getIsWinner() {
		return this.isWinner;
	}

	public bool getIsTurn() {
		return this.isTurn;
	}

	public int getBallsAvailable() {
		return this.ballsAvailable;
	}
}
