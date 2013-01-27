using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseUp () {
    	print ("Game Over screen clicked.");
		gameObject.guiTexture.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
