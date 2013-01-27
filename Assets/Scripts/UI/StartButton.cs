using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	
	public GUITexture welcomeScreenBottom;
	public GUITexture welcomeScreenTop;
	public GUITexture welcomeScreen;
	public GUITexture startButton;
	public GUITexture twoPlayersButton;
	public GUITexture threePlayersButton;
	public GUITexture quitButton;
	public GUITexture twoPlayerMouseover;
	public GUITexture threePlayerMouseover;
	public GUITexture loadingScreen;
	public Texture mouseOverTexture;
	public Texture twoPlayerInstructions;
	public Texture threePlayerInstructions;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseOver() {
    	welcomeScreenBottom.texture = mouseOverTexture;
		twoPlayerMouseover.enabled = false;
		threePlayerMouseover.enabled = false;
    }
	
	void OnMouseUp () {
    	print ("Start button clicked.");
		
		//if (AppManager.Instance.playerCount == 2)
		//{
		//	loadingScreen.guiTexture.texture = twoPlayerInstructions;
		//}
		//else
		//{
			loadingScreen.guiTexture.texture = threePlayerInstructions;
		//}
		
		welcomeScreen.enabled = false;
		welcomeScreenBottom.enabled = false;
		welcomeScreenTop.enabled = false;
		startButton.enabled = false;
		twoPlayersButton.enabled = false;
		threePlayersButton.enabled = false;
		twoPlayerMouseover.enabled = false;
		threePlayerMouseover.enabled = false;
		audio.pitch = 1.0f;
		audio.Play();

		Application.LoadLevel (Application.loadedLevel + 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
