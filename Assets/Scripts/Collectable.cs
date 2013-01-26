using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class Collectable : MonoBehaviour {
		
	public enum ItemType
	{
		Normal = 0,
		GhostKey,
		LockKey,
	}

	public bool autoPickup = false;
	public ItemType itemType = ItemType.Normal;
	
	void Start ()
	{
		// Done because we never want to collide with this object, only pick it up.
		collider.isTrigger = true;
	}
	
	public void EnterCollectable ( )
	{
		//TODO : show response to nearby collector
	}
	
	public void StayCollectable ( )
	{
		transform.Rotate(Vector3.up,Time.deltaTime * 100);		
	}
	public void Collected ( )
	{
		collider.enabled = false;
	}
	
	public void Released ( )
	{
		collider.enabled = true;
		// This is so the collector doesn't pick them right back up
		autoPickup = false;
	}
	
	public void ExitCollectable ( )
	{
		//TODO : show response to nearby collector
	}

}
