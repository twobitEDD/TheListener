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

			Transform winScreen = menuObject.transform.FindChild("GhostWinScreen");
			winScreen.gameObject.SetActive(false);
			
			AppManager.Instance.ghostWinScreen = winScreen.gameObject;
			
			winScreen = menuObject.transform.FindChild("HumanWinScreen");
			winScreen.gameObject.SetActive(false);
			AppManager.Instance.humanWinScreen = winScreen.gameObject;
		}
		SetupMultiplayer();
	}
	void SetupMultiplayer()
	{
		// Since the game is by default setup for 3 people, if there is 2, we just need to get rid of the 2nd human player
		if ( AppManager.Instance.playerCount == 2 )
		{
			Camera ourCamera0 = GameObject.FindGameObjectWithTag("Camera0").camera;
			ourCamera0.rect = new Rect(0,0,1,1);
			// Kill the extra!
			GameObject ourPlayer1 = GameObject.FindGameObjectWithTag("Player1");
			ourPlayer1.SetActive(false);
			GameObject ourCamera1 = GameObject.FindGameObjectWithTag("Camera1");
			ourCamera1.SetActive(false);
		}
	}
}
