using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public enum playerControlIndex
	{
		Player1 = 0,
		Player2
	}
	public playerControlIndex playerIndex = playerControlIndex.Player1;
	protected Animator animator;
	public float DirectionDampTime = .25f;
	public bool ApplyGravity = true; 
	public Collector ourCollector;
	public GameObject ourGameObject;
	
	// Use this for initialization
	void Start () 
	{
		if (null == ourGameObject )
		{
			ourGameObject = gameObject;
		}
		if (null == ourCollector )
		{
			ourCollector = ourGameObject.GetComponent<Collector>();
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
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);			
			if ( animator.GetBool("Hi"))
			{
				animator.SetBool("Hi", false);
			}
			// If we're not running, pick up the object
			if (!stateInfo.IsName("Arms Layer.Wave") && !stateInfo.IsName("Base Layer.Run") )
			{
				if (Input.GetButton("A" + ((int)playerIndex).ToString()))
				{
					animator.SetBool("Hi", true);
					ourCollector.RequestPickup();
            	}
			}

			if(Input.GetButtonDown("B" + ((int)playerIndex).ToString() ) )
			{
				ourCollector.ReleaseAll();
			}
			
		
      		float h = Input.GetAxis("Horizontal" + ((int)playerIndex).ToString() );
        	float v = Input.GetAxis("Vertical" + ((int)playerIndex).ToString() );
			
			animator.SetFloat("Speed", v);
            animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);	
		}   		  
	}
}
