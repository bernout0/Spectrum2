using UnityEngine;
using System.Collections;

public class AnimateLight : MonoBehaviour {
	
	public AnimationCurve intensity;
	public AnimationCurve range;
	
	private float animationLength;
	private float startTime;
	
	public IEnumerator StartAnimating () {
		animationLength = intensity.length;
		startTime = Time.time;
		
		if(light)
		{
			light.enabled = true;
			
			for(;;)
			{
				light.intensity = intensity.Evaluate( Time.time - startTime );
				light.range = range.Evaluate( Time.time - startTime );
				
				if(animationLength <= Time.time - startTime)
				{
					light.enabled = false;
					yield break;
				}else{
					yield return new WaitForSeconds(Time.deltaTime);
				}
			}
		}else{
			yield break;
		}
	}
}
