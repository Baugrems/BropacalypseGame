using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chadWalking : MonoBehaviour {

	public float xmin;
	public float xmax;
	public float padding = 1f;
	public GameObject chatScript;
	public LevelManager levelManager;
	public AudioClip clip;

	private int spriteSteps;

	public Sprite[] chadSprite;

	// Use this for initialization
	void Start () {
		AudioSource.PlayClipAtPoint (clip, this.transform.position);
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
		spriteSteps = 0;
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.D)) {
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x + .1f, xmin, xmax), transform.position.y,transform.position.z);
			loadNextSprite();
		} else if (Input.GetKey(KeyCode.A)) {
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x - .1f, xmin, xmax),transform.position.y,transform.position.z);
			loadNextSprite();
		} else if (Input.GetKeyDown(KeyCode.Space)) {
			AudioSource.PlayClipAtPoint (clip, this.transform.position);
			GetComponent<SpriteRenderer> ().sprite = chadSprite[3];
			if (chatScript.GetComponent<chatHandler> ().chatted == true) {
				chatScript.GetComponent<chatHandler> ().chatty.text = "You will pay for this!\n\n" +
				"Come get some, bro!" +
				"\n\nPress Spacebar to Continue";
			}
		}
	}

	void loadNextSprite (){
		if (spriteSteps == 3) {
			spriteSteps++;
		}
		if (spriteSteps < chadSprite.Length) {
			GetComponent<SpriteRenderer> ().sprite = chadSprite [spriteSteps];
			spriteSteps++;
		} else {
			spriteSteps = 0;
			loadNextSprite ();
		}
	}
}
