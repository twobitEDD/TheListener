using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntryPoint : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () 
	{
		if ( Application.loadedLevel == 0 )
		{
			HandleWelcomeScreen ();
		}
		else
		{
			HandleGameplayBegin();
		}
	}
	
	void HandleWelcomeScreen()
	{		
		Object load = Resources.Load("UI");
		
       	if ( load )
       	{
			GameObject menuObject = (GameObject)MonoBehaviour.Instantiate(load);
			menuObject.SetActive(true);
		}
		
	}
	
	void HandleGameplayBegin ()
	{
		Object load = Resources.Load("UI_Gameplay");
		
       	if ( load )
       	{
			GameObject menuObject = (GameObject)MonoBehaviour.Instantiate(load);
			menuObject.SetActive(true);
			
			Transform gameplayLoading = menuObject.transform.FindChild("Loading");
			gameplayLoading.gameObject.SetActive(true);
		}
		
	}
	
}
