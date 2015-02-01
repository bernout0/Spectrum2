using UnityEngine;
using System.Collections;

public class MagicBall : MonoBehaviour {
	
	public float speed = 5f;
	public bool animate;
	public float delay = 1.5f;
	private Vector3 startPos;
	public GameObject hitEffect;
	
	public void startAnimation()
	{
		StartCoroutine(activate());
	}
	
	public IEnumerator activate()
	{
		yield return new WaitForSeconds(delay);
		startPos = transform.position;
		particleSystem.Play();
		animate = true;
	}
	
	void Update () {
		if(animate)
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		
			if(!particleSystem.isPlaying)
			{
				GameObject e = Instantiate( hitEffect, transform.position, Quaternion.identity) as GameObject;
				e.particleSystem.Play();
				Destroy ( e, 5f );
				transform.position = startPos;
				animate = false;
			}	
		}
	}
}
