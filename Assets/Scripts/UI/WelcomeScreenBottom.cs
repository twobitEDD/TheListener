using UnityEngine;
using System.Collections;

public class WelcomeScreenBottom : MonoBehaviour {
	
	public GUITexture bottomScreen;
	public Texture defaultBottomScreenTexture;
	public GUITexture twoPlayerMouseover;
	public GUITexture threePlayerMouseover;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseUp () {
    	print ("Bottom of welcome screen clicked.");
	}
	
	void OnMouseOver() {
    	bottomScreen.texture = defaultBottomScreenTexture;
		twoPlayerMouseover.enabled = false;
		threePlayerMouseover.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
