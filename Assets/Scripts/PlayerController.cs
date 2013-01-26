using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	protected Animator animator;
	public float DirectionDampTime = .25f;
	public bool ApplyGravity = true; 

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		
		if(animator.layerCount >= 2)
			animator.SetLayerWeight(1, 1);
	}
		
	// Update is called once per frame
	void Update () 
	{

		if (animator)
		{
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);			
			// If we're not running, pick up the object
			if (stateInfo.IsName("Arms Layer.Wave") && animator.GetBool("Hi"))
			{
				animator.SetBool("Hi", false);				
			}
			if (!stateInfo.IsName("Arms Layer.Wave"))
			{
				if (Input.GetButton("Fire1"))
				{
					animator.SetBool("Hi", true);                
            	}
			}
			//else
			//{
			//	animator.SetBool("Jump", false);                
            //}

			if(Input.GetButtonDown("Fire2") && animator.layerCount >= 2)
			{
				//animator.SetBool("Hi", !animator.GetBool("Hi"));
			}
			
		
      		float h = Input.GetAxis("Horizontal");
        	float v = Input.GetAxis("Vertical");
			
			animator.SetFloat("Speed", h*h+v*v);
            animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);	
		}   		  
	}
}
