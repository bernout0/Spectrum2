using UnityEngine;
using System.Collections;

public class LightFlickerAnimation : MonoBehaviour {

	public AnimationCurve lightIntensity;
	public ParticleSystem p;
	
	public int lastParticleCount;
	
	void Start()
	{
		lastParticleCount = p.particleCount;
	}
	
	void Update () {
		int diff = p.particleCount - lastParticleCount;
		
		if( diff > 0 )
		{
			light.intensity += diff / (p.particleCount /2f);
		}else{
			light.intensity -= .1f * Time.time;
		}
		
		lastParticleCount = p.particleCount;
	}
}
