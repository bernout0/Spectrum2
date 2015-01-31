// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Play : MonoBehaviour {
	private CardboardHead head;
	private Vector3 startingPosition;
	
	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
		CardboardGUI.IsGUIVisible = true;
		CardboardGUI.onGUICallback += this.OnGUI;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (isLookedAt) {
			GetComponent<Renderer>().material.color = Color.blue;
				}
		else
		GetComponent<Renderer>().material.color = this.audio.volume == 0 ? Color.white : Color.red;

		if ((Cardboard.SDK.CardboardTriggered || Input.GetKeyDown ("space"))  && isLookedAt) {
		if(this.audio.volume == 0)
				this.audio.volume = Mathf.Lerp(0f, 1f , 1f);
		else if(this.audio.volume != 0)
				this.audio.volume = Mathf.Lerp(1f, 0f , 1f);
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
