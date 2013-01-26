using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collector : MonoBehaviour {
		
	// If an object is collected, should we keep it active while its collected
	public bool hideCollectedObject = false; 
	
	// If an object is collected, where should we position it
	public Transform attachPoint;
	
	// Make the collected objects a child of our transform attachPoint
	public bool makeAttachPointParent = true; // if false, the object is placed in the same location as the attachPoint, but doesn't parent it.
	
	// Since we might put the object we collect anywhere (via child/parent relationships) we need to make a list of those objects.
	public List<Collectable> collection;
	
	// used to only allow a certain number of objects to be collected.
	public int maxCollectionSize = 1; // Wasn't sure what we wanted to do here, but i also want to be able to reuse this code :P
	
	public float pickupRequestWindow = 1.0f;
	float pickupRequestTime;
	
	// Shows if the collected is interested in this object.
	public bool pickupRequested;
	
	public void RequestPickup ( )
	{
		pickupRequested = true;
		Invoke("EndPickupRequest", pickupRequestWindow );
		pickupRequestTime = Time.realtimeSinceStartup;
	}
	
	void EndPickupRequest ()
	{
		// Check to see if another pick request came in after this one's Invoke was popped.
		if ( Time.realtimeSinceStartup - pickupRequestTime > pickupRequestWindow ) 
		{
			pickupRequested = false;
		}
	}
	
	// Attempts to collect an object
	public bool Collect ( Collectable other )
	{
		if ( maxCollectionSize <= collection.Count )
		{
			return false;
		}
		if ( false == collection.Contains ( other ) )
		{
			collection.Add ( other );
			other.Collected ();
			if ( makeAttachPointParent )
			{
				other.gameObject.transform.parent	= attachPoint;
				other.transform.position 			= Vector3.zero;
				other.transform.localPosition 		= Vector3.zero;
			}
			else
			{
				other.transform.position 			= attachPoint.position;
				other.transform.localPosition 		= Vector3.zero;				
			}
		}
		return true;
	}
	
	// Lets go of an object, does NOT reposition anywhere.	
	public void Release ( Collectable other )
	{
		if ( collection.Contains ( other ) )
		{
			collection.Remove ( other );
			other.Released ();
			if ( makeAttachPointParent )
			{
				other.transform.parent = null;
			}
		}
	}
	public void ReleaseAll ( )
	{
		foreach ( Collectable item in collection )
		{
			item.Released ();
			if ( makeAttachPointParent )
			{
				item.transform.parent = null;
			}
		}
		collection.Clear();
	}
	// Returns a ref to the object if found, else returns null
	public Collectable holdsCollectableType(Collectable.ItemType itemType )
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
		// Did we collide with a collectable object's trigger
		if ( collectObj != null )
		{
			// Tell the object it can be picked up encase it cares
			collectObj.EnterCollectable();
			
			// automatically collect if autoPickup.
			// pickupRequested means that if an object isn't autoPickup'd, the Collector wants to pick it up
			if ( pickupRequested || collectObj.autoPickup )
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
			collectObj.StayCollectable();
			
			// automatically collect if autoPickup.
			// pickupRequested means that if an object isn't autoPickup'd, the Collector wants to pick it up
			if ( pickupRequested || collectObj.autoPickup )
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
			// Tell the object it can no longer be picked up, encase it cares
			collectObj.ExitCollectable();
		}
	}

}
