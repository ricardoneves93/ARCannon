using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player {
	private int[] score = new int[5];
	private string name;
	private bool isWinner;
	private bool isTurn;
	private int[] ballsAvailable = new int[5];
	public Text scoreText;
	public Text nameText;

	public Player(int ballsAvailable, string name){

		for (int i = 0; i < score.Length; i++)
			score [i] = 0;

		for (int i = 0; i < this.ballsAvailable.Length; i++)
			this.ballsAvailable [i] = ballsAvailable;

		this.isWinner = false;
		this.name = name;
	}

	public void addScore(int score){
		this.score[GameMaster.currentScene] += score;
		this.scoreText.text = "Score: " + this.score[GameMaster.currentScene].ToString ();
	}

	public void changeTurn(){
		if (this.isTurn) {
			this.scoreText.enabled = false;
			this.nameText.enabled = false;
			//this.ballsText.enabled = false;
		} else {
			this.scoreText.enabled = true;
			this.nameText.enabled = true;
			//this.ballsText.enabled = true;
		}

		this.isTurn = !this.isTurn;
	}

	public void removePlayerBall() {
		this.ballsAvailable[GameMaster.currentScene]--;
		//this.ballsText.text = "Balls left: " + ballsAvailable[GameMaster.currentScene].ToString ();
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
		//this.ballsText = ballsText;

		this.scoreText.text = "Score: " + score[GameMaster.currentScene].ToString ();
		this.nameText.text = name;
		//this.ballsText.text = "Balls left: " + ballsAvailable[GameMaster.currentScene].ToString();

		this.scoreText.enabled = false;
		this.nameText.enabled = false;
		//this.ballsText.enabled = false;
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
		return this.ballsAvailable[GameMaster.currentScene];
	}
}
