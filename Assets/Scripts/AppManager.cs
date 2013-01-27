using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppManager : MonoBehaviour {
	
	public GUITexture welcomeScreenTexture;
	
	public GameObject ghostWinScreen;
	public GameObject humanWinScreen;
	public GameObject blackScreenFill;
	
	public bool activeGame = false;
	
	// TODO: Make a copy of the item which the humans are looking for to display on screen
	//public GameObject winningObjectCopy;
	
	private static AppManager instance;
	
	public int playerCount = 2;
	public int deathCount = 0;
	
	public static AppManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameObject ("AppManager").AddComponent<AppManager> ();
			}
 
			return instance;
		}
	}
 
	public void OnApplicationQuit ()
	{
		instance = null;
	}
	
	public void DisplayMessage(string message)
	{
		Object load = Resources.Load("PickupInfo");
		GameObject guiTextObj;
		if ( load )
       	{
			guiTextObj = (GameObject)MonoBehaviour.Instantiate(load);
			GUIText guiText = guiTextObj.GetComponent<GUIText>();
			if( guiText)
			{
				guiText.text = message;
			}

		}
	}
	
	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(this);
	}
	
	public void BeginGame ()
	{
		LoadCollectables();
		activeGame = true;
	}
	
	void LoadCollectables()
	{
		List<GameObject> collectableHostLocations = new List<GameObject>();
		GameObject[] temp = GameObject.FindGameObjectsWithTag("CollectableHost");
		collectableHostLocations.AddRange ( temp );
		
		List<GameObject> collectables = new List<GameObject>();
		GameObject[] temp2 = GameObject.FindGameObjectsWithTag("Collectable");
		collectables.AddRange ( temp2 );
		
		bool ghostKeySet = false;
		foreach ( GameObject collectableObj in collectables )
		{
			int randIndex = Random.Range(0, collectableHostLocations.Count);
			collectableObj.transform.parent = collectableHostLocations[randIndex].transform;
			collectableObj.transform.position = Vector3.zero;
			collectableObj.transform.localPosition = Vector3.zero;

			collectableHostLocations.RemoveAt(randIndex);
			
			if (!ghostKeySet)
			{
				Collectable winObject = collectableObj.GetComponent<Collectable>();
				
				winObject.itemType = Collectable.ItemType.GhostKey;

				// TODO: Make a copy of the item which the humans are looking for to display on screen

				ghostKeySet = true;
			}

		}
	}

	public void BeginGameOver ()
	{
		activeGame = false;
		blackScreenFill.SetActive(true);
		GuiTextureAutoFade blackScreenFade = blackScreenFill.AddComponent<GuiTextureAutoFade>();
		blackScreenFade.fadeDuration = 10.0f;
		blackScreenFade.performFade();
		Invoke ( "RollCredits0", 10.0f );
	}
	public void RollCredits0 ()
	{
		
		ghostWinScreen.SetActive(false);	
		humanWinScreen.SetActive(false);
		
		DisplayMessage("Game Developers for Phantom Listener: ");
		Invoke ( "RollCredits1", 5.0f );
	}
	public void RollCredits1 ()
	{
		DisplayMessage("Matthew Z Haralovich(Zon): Tallest Person ");
		Invoke ( "RollCredits2", 5.0f );
	}
	public void RollCredits2 ()
	{
		DisplayMessage("Nick Johns(...): Preferences Not Found ");
		Invoke ( "RollCredits3", 5.0f );
	}
	public void RollCredits3 ()
	{
		DisplayMessage("Edd Norris(EDDnorris): #CoffeeChug ");
		Invoke ( "RollCredits4", 5.0f );
	}
	public void RollCredits4 ()
	{
		DisplayMessage("Gabe Recchia(Rudebrazen): !Greg ");
		Invoke ( "RollCredits0", 5.0f );
	}
	
	void OnGUI() {
		//welcomeScreenTexture.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
