using UnityEngine;
using System.Collections;

public class LoadingScreenButton : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	
	void OnMouseUp () {
		//AppManager.Instance.DisplayMessage("3 player button clicked.");
    	print ("Loading screen button clicked.");
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
