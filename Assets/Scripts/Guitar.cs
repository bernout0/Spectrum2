using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Guitar : MonoBehaviour {

	private CardboardHead head;
	private Vector3 startingPosition;
	public Material material1;
	public Material material2;
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
		CardboardGUI.IsGUIVisible = true;
		CardboardGUI.onGUICallback += this.OnGUI;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		GetComponent<Renderer>().material = isLookedAt == false ? material1 : material2;
		
		if (isLookedAt) {
			this.audio.volume = 1f;
		}
		else {
			this.audio.volume = 0f;
				}
	}
	
	void OnGUI() {
		if (!CardboardGUI.OKToDraw(this)) {
			return;
		}
		if (GUI.Button(new Rect(50, 50, 200, 50), "Reset")) {
			transform.localPosition = startingPosition;
		}
	}
}
