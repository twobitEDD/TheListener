using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppManager : MonoBehaviour {
	
	public GUITexture welcomeScreenTexture;
	
	private static AppManager instance;
	
	public int playerCount = 2;
 
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
	
	void LoadCollectables()
	{
		List<GameObject> collectableHostLocations = new List<GameObject>();
		GameObject[] temp = GameObject.FindGameObjectsWithTag("CollectableHost");
		collectableHostLocations.AddRange ( temp );
		
		List<GameObject> collectables = new List<GameObject>();
		GameObject[] temp2 = GameObject.FindGameObjectsWithTag("Collectables");
		collectables.AddRange ( temp2 );
		
		bool ghostKeySet = false;
		foreach ( Collectable collectableObj in collectables )
		{
			int randIndex = Random.Range(0, collectableHostLocations.Count);
			collectableObj.transform.parent = collectableHostLocations[randIndex].transform;
			collectableObj.transform.position = Vector3.zero;
			collectableObj.transform.localPosition = Vector3.zero;

			collectableHostLocations.RemoveAt(randIndex);
			
			if (!ghostKeySet)
			{
				collectableObj.itemType = Collectable.ItemType.GhostKey;	
				ghostKeySet = true;
			}

		}
	}
	
	void OnGUI() {
		//welcomeScreenTexture.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
