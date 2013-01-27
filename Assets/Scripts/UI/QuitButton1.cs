using UnityEngine;
using System.Collections;

public class QuitButton1 : MonoBehaviour {
	
	public GUITexture twoPlayerMouseover;
	public GUITexture threePlayerMouseover;
	public GUITexture bottomScreen;
	public Texture mouseOverTexture;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseUp () {
    	print ("Quit button clicked.");
		Application.Quit();
	}
	
	void OnMouseOver() {
    	bottomScreen.texture = mouseOverTexture;
		twoPlayerMouseover.enabled = false;
		threePlayerMouseover.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
