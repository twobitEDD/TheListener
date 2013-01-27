using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntryPoint : MonoBehaviour {
	
	// Use this for initialization
	void Start () 
	{
		
		Object load = Resources.Load("UI");
       	if ( load )
       	{
			GameObject menuObject = (GameObject)MonoBehaviour.Instantiate(load);
		}
	}
	
	
	
}
