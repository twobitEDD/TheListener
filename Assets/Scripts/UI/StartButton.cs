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
	public GUITexture ghostWinScreen;
	public GUITexture humanWinScreen;
	public GUITexture twoPlayerMouseover;
	public GUITexture threePlayerMouseover;
	public Texture mouseOverTexture;
	
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
		welcomeScreen.enabled = false;
		welcomeScreenBottom.enabled = false;
		welcomeScreenTop.enabled = false;
		startButton.enabled = false;
		twoPlayersButton.enabled = false;
		threePlayersButton.enabled = false;
		twoPlayerMouseover.enabled = false;
		threePlayerMouseover.enabled = false;
		ghostWinScreen.enabled = false;
		humanWinScreen.enabled = false;
		
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
