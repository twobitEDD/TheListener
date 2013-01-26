using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collector : MonoBehaviour {
	
	public List<Collectable> collection;
	public Transform attachPoint;
	public bool actionRequested;
	
	public void Collect ( Collectable other )
	{
		if ( false == collection.Contains ( other ) )
		{
			collection.Add ( other );
			other.Collected ();
			other.gameObject.transform.parent	= attachPoint;
			other.transform.position = Vector3.zero;
			other.transform.localPosition = Vector3.zero;
		}
	}
	
	public void Release ( Collectable other )
	{
		if ( collection.Contains ( other ) )
		{
			collection.Remove ( other );
			other.Released ();
			other.transform.parent = null;
		}		
	}
	
	public Collectable findCollectableType(Collectable.ItemType itemType )
	{
		foreach ( Collectable item in collection )
		{
			if ( item.itemType == itemType )
			{
				return item;
			}
		}
		return null;
	}
	
	public void OnTriggerEnter ( Collider other )
	{
		Collectable collectObj = other.GetComponent<Collectable>();
		if ( collectObj != null )
		{
			collectObj.EnterCollectable();
			// automatically collect if no action is required.
			// actionRequested means that if it is required, collect works
			if ( actionRequested || false == collectObj.requireAction )
			{
				Collect ( collectObj );
			}
		}
	}
	public void OnTriggerStay ( Collider other )
	{
		Collectable collectObj = other.GetComponent<Collectable>();
		if ( collectObj != null )
		{
			// automatically collect if no action is required.
			// actionRequested means that if it is required, collect works
			if ( actionRequested || false == collectObj.requireAction )
			{
				Collect ( collectObj );
			}
		}
	}
	public void OnTriggerExit ( Collider other )
	{
		Collectable collectObj = other.GetComponent<Collectable>();
		if ( collectObj != null )
		{
			collectObj.ExitCollectable();
		}
	}

}
