using UnityEngine;
using System.Collections;

public class ThreePlayersButton : MonoBehaviour {
	
	public GUITexture twoPlayerMouseover;
	public GUITexture threePlayerMouseover;
	public GUITexture guiTextureToChange;
	public Texture newGUITexture;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseOver() {
    	twoPlayerMouseover.enabled = false;
		threePlayerMouseover.enabled = true;
    }
	
	void OnMouseUp () {
		//AppManager.Instance.DisplayMessage("3 player button clicked.");
    	print ("3 player button clicked.");
		guiTextureToChange.texture = newGUITexture;
		AppManager.Instance.playerCount = 3;
		audio.pitch = 0.7f;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
