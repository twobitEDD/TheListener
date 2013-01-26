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

	public bool requireAction = false;
	public ItemType itemType = ItemType.Normal;
	
	void Start ()
	{
		// Done because we never want to run into this object, only pick it up.
		collider.isTrigger = true;
	}
	
	public void EnterCollectable ( )
	{
		//TODO : show response to nearby collector
	}
	
	public void Collected ( )
	{
		collider.enabled = false;
	}
	
	public void Released ( )
	{
		collider.enabled = true;
		// This is so the collector doesn't pick them right back up
		requireAction = true;
	}
	
	public void ExitCollectable ( )
	{
		//TODO : show response to nearby collector		
	}

}
