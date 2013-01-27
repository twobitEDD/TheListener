using UnityEngine;
using System.Collections;

public class GuiTextureAutoFade : MonoBehaviour {
	
	public bool fadeIn = true;
	public bool performBoth = false;
	public float fadeDuration = 3.0f;
	public bool performOnStart = false;
     
    private void Start ()
    {
		if ( performOnStart )
		{
	        StartCoroutine(StartFading());
		}
    }
	
	public void performFade ()
	{
		StartCoroutine(StartFading());
	}
 
    private IEnumerator StartFading()
    {
		if ( fadeIn )
		{
	        yield return StartCoroutine(Fade(0.0f, 1.0f, fadeDuration));
		}
		else
		{
		    yield return StartCoroutine(Fade(1.0f, 0.0f, fadeDuration));			
		}
	
		if ( performBoth )
		{
			if ( fadeIn )
			{
		        yield return StartCoroutine(Fade(1.0f, 0.0f, fadeDuration));		
			}
			else
			{
		        yield return StartCoroutine(Fade(0.0f, 1.0f, fadeDuration));
			}			
		}
    }
     
    private IEnumerator Fade (float startLevel, float endLevel, float time)
    {
       float speed = 1.0f/time;
       
       for (float t = 0.0f; t < 1.0; t += Time.deltaTime*speed)
       {
           float a = Mathf.Lerp(startLevel, endLevel, t);
           guiTexture.color = new Color(guiTexture.color.r,
               guiTexture.color.g,
               guiTexture.color.b, a);
           yield return 0;
       }
    }
}
