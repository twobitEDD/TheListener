using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplicationManager : MonoBehaviour {
	
	public List<Collectable> collectableObjects;
		
	// Use this for initialization
	void Start () 
	{
		List<GameObject> collectableHostLocations = new List<GameObject>();
		GameObject[] temp = GameObject.FindGameObjectsWithTag("CollectableHost");
		collectableHostLocations.AddRange ( temp );
		foreach ( Collectable collectableObj in collectableObjects ) 
		{
			int randIndex = Random.Range(0, collectableHostLocations.Count);
			collectableObj.transform.parent = collectableHostLocations[randIndex].transform;
			collectableObj.transform.position = Vector3.zero;
			collectableObj.transform.localPosition = Vector3.zero;
			collectableHostLocations.RemoveAt(randIndex);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
