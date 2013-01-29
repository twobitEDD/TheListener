using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

	protected Animator animator;
	public float DirectionDampTime = .25f;
	public bool ApplyGravity = true; 
	
	public float isVisibleWindow = 2.0f;
	float lastVisibleTimer;
	//public Collector ourCollector;
	public GameObject ourGameObject;
	
	public int renderLayerMiniMap = 8;
	public int renderLayerNoCamera = 9;
	
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
		
		//Show the ghost on spawn.
		// Which inits the last visible timer.
		HandleGhostAttack();
	}
		
	// Update is called once per frame
	void Update () 
	{
		if ( !AppManager.Instance.activeGame )
		{
			return;
		}
		if (animator)
		{
      		float h = Input.GetAxis("Horizontal-1");
        	float v = Input.GetAxis("Vertical-1");
			//ajDebug.Log ( " h : " + h + " v : " + v );
			rigidbody.AddForce( h, 0, v, ForceMode.VelocityChange );
			
			//rigidbody.AddForce(transform.right * h, ForceMode.VelocityChange );
			animator.SetFloat("Speed", v);
            animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);	
			
			if( Input.GetButtonDown("A-1" ) && Time.realtimeSinceStartup - lastVisibleTimer > isVisibleWindow )
			{
				HandleGhostAttack();
			}
		}   		  
	}
	
	void HandleGhostAttack ( )
	{
		audio.Play();

		if ( gameObject.layer == renderLayerNoCamera )
		{
			SetLayerRecursively(gameObject, renderLayerMiniMap);

			Invoke("ResetLayerIndex", isVisibleWindow );
		
			lastVisibleTimer = Time.realtimeSinceStartup;
		}
		

	}
	
	void ResetLayerIndex ()
	{
		{
			if ( gameObject.layer == renderLayerMiniMap )
			{
				SetLayerRecursively(gameObject, renderLayerNoCamera);
			}
			lastVisibleTimer = 0;
		}
	}

	void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (null == obj)
        {
            return;
        }
        
      	obj.layer = newLayer;
       
        foreach (Transform child in obj.transform)
        {
            if (null == child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
	
}
