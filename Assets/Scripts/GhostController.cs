using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

	protected Animator animator;
	public float DirectionDampTime = .25f;
	public bool ApplyGravity = true; 
	//public Collector ourCollector;
	public GameObject ourGameObject;
	
	// Use this for initialization
	void Start () 
	{
		if (null == ourGameObject )
		{
			ourGameObject = gameObject;
		}
		animator = ourGameObject.GetComponent<Animator>();
		
		if(animator.layerCount >= 2)
			animator.SetLayerWeight(1, 1);
	}
		
	// Update is called once per frame
	void Update () 
	{
		if (animator)
		{		
      		float h = Input.GetAxis("Horizontal-1");
        	float v = Input.GetAxis("Vertical-1");
			//ajDebug.Log ( " h : " + h + " v : " + v );
			rigidbody.AddForce( h, 0, v, ForceMode.VelocityChange );
			
			//rigidbody.AddForce(transform.right * h, ForceMode.VelocityChange );
			animator.SetFloat("Speed", v);
            animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);	
		}   		  
	}
	
}
