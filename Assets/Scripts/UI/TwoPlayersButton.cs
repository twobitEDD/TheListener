using UnityEngine;
using System.Collections;

public class TwoPlayersButton : MonoBehaviour {
	
	public GUITexture twoPlayerMouseover;
	public GUITexture threePlayerMouseover;
	public GUITexture guiTextureToChange;
	public Texture newGUITexture;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseOver() {
    	twoPlayerMouseover.enabled = true;
		threePlayerMouseover.enabled = false;
    }
	
	void OnMouseUp () {
    	print ("2 player button clicked.");
		guiTextureToChange.texture = newGUITexture;
		AppManager.Instance.playerCount = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
