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

	string[] scenes = {"Level1", "Level2", "Level3", "Level4", "Level5"};

	// Use this for initialization
	void Start () {

		GameMaster.result = this.result;
		GameMaster.scenes = this.scenes;
		GameMaster.levels = this.levels;
		GameMaster.imageBalls = this.imageBalls;
		GameMaster.player1.setLabels (score1, player1);
		GameMaster.player2.setLabels (score2, player2);

		// set players turns
		GameMaster.setInitialTurns ();

	}
	
	// Update is called once per frame
	void Update () {
		Player player;

		if (GameMaster.player1.getIsTurn ())
			player = GameMaster.player1;
		else
			player = GameMaster.player2;




		// If no balls available
		if (player.getBallsAvailable () == 0 && !GameMaster.isChangingLevel) {
			if (GameMaster.nothingMoving () && GameMaster.noBalls()) {
				GameMaster.changePlayersTurns ();
				// reset to first balls image
				Texture2D texture = new Texture2D(592, 144);
				
				FileStream fs = new FileStream("Assets/Images/cannonballs4.png", FileMode.Open, FileAccess.Read);
				byte[] imageData = new byte[fs.Length];
				fs.Read(imageData, 0, (int) fs.Length);
				texture.LoadImage(imageData);
				
				GameMaster.imageBalls.texture = texture;
			}
		} else if (GameMaster.getActiveBarrels () == 0 && !GameMaster.isChangingLevel) {
			GameMaster.changePlayersTurns ();
			// reset to first balls image
			Texture2D texture = new Texture2D(592, 144);
			
			FileStream fs = new FileStream("Assets/Images/cannonballs4.png", FileMode.Open, FileAccess.Read);
			byte[] imageData = new byte[fs.Length];
			fs.Read(imageData, 0, (int) fs.Length);
			texture.LoadImage(imageData);
			
			GameMaster.imageBalls.texture = texture;
		}
	}
}
