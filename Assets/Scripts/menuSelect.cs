using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class menuSelect : MonoBehaviour {
	private CardboardHead head;
	private Vector3 startingPosition;
	public string scene;
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
		CardboardGUI.IsGUIVisible = true;
		CardboardGUI.onGUICallback += this.OnGUI;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		GetComponent<Renderer>().material.color = isLookedAt ? Color.white : Color.gray;
		if (Cardboard.SDK.CardboardTriggered && isLookedAt) {
			Application.LoadLevel(scene);
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