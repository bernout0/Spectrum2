using UnityEngine;
using System.Collections;

public class PlayEffects : MonoBehaviour {
	
	public ParticleSystem[] effects;
	public AnimateLight magicLight;
	public AnimateLight fireLight;
	
	public OtherButton fire;
	public OtherButton magic;
	public OtherButton ray;
	
	void Start()
	{
		if(animation.isPlaying)
			{
				magic.SetUnclicked();
				return;
			}
		
			animation.Play("Magic");
			magicLight.StartCoroutine( "StartAnimating" );
			effects[5].Play();
			effects[6].GetComponent<MagicBall>().startAnimation();
			magic.SetUnclicked();
	}
	
	void Update()
	{
		if(fire.clicked)
		{
			if(animation.isPlaying)
			{
				magic.SetUnclicked();
				return;
			}
				
		
			animation.Play("Fire");
			effects[0].Play();
			effects[1].Play();
			fire.SetUnclicked();
		}
		
		if(magic.clicked)
		{
			if(animation.isPlaying)
			{
				magic.SetUnclicked();
				return;
			}
		
			animation.Play("Magic");
			magicLight.StartCoroutine( "StartAnimating" );
			effects[5].Play();
			effects[6].GetComponent<MagicBall>().startAnimation();
			magic.SetUnclicked();
		}
		
		if(ray.clicked)
		{
			if(animation.isPlaying)
			{
				ray.SetUnclicked();
				return;
			}
			
			animation.Play("Ray");
			effects[2].Play();
			effects[3].Play();
			effects[4].Play();
			fireLight.StartCoroutine( "StartAnimating" );
			ray.SetUnclicked();
		}
	}
}
