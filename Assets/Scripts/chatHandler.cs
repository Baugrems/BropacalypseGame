using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chatHandler : MonoBehaviour {
	public Text chatty;
	public Image chatbox;
	public bool chatted = false;

	void OnTriggerEnter2D(Collider2D trigger) {
		chatbox.transform.position = new Vector3 (400f, 400f, 0f);
		chatty.text = "Aha! Looks like you are missing your prized belt, Chad.\n\n" +
			"Press Space to Continue";
		chatted = true;

	}
		
}
