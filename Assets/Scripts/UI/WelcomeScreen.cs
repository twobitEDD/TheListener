using UnityEngine;
using System.Collections;

public class WelcomeScreen : MonoBehaviour {
	
	public GUITexture bottomScreen;
	public Texture defaultBottomScreenTexture;
	public GUITexture twoPlayerMouseover;
	public GUITexture threePlayerMouseover;
	
	// Use this for initialization
	void Start () {
		twoPlayerMouseover.enabled = false;
		threePlayerMouseover.enabled = false;
	}
	
	void OnMouseUp () {
    	print ("Top of welcome screen clicked.");
		
		//gameObject.guiTexture.enabled = false;
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
