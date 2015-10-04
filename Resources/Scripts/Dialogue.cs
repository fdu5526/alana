using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour {

	public float duration;
	public float fadeDuration;

	float startTime;
	bool started;
	SpriteRenderer speechBubble;

	// Use this for initialization
	void Start () {
		GetComponent<TextMesh>().color = new Color(1f,1f,1f,0f);
		GetComponent<MeshRenderer>().sortingOrder = 3000;
		started = false;

		Transform s = GetComponent<Transform>().Find("SpeechBubble");
		if (s != null) {
			speechBubble = s.gameObject.GetComponent<SpriteRenderer>();
			speechBubble.color = new Color(0f,0f,0f,0f);
		}
		
	}

	public void Display () {
		startTime = Time.time;
		started = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (started ) { // display full color
			
			float d = 0f;

			if (Time.time - startTime < fadeDuration) { // fade in
				d = (Time.time - startTime) / fadeDuration;
			}else if (Time.time - startTime < duration + fadeDuration) { // full color
				d = 1f;
			} else if (Time.time - startTime < duration + 2f*fadeDuration) { // fade out
				d = 1f - (Time.time - startTime - fadeDuration - duration) / fadeDuration;
			} else {
				started = false;
			}
			if (speechBubble != null) {
				speechBubble.color = new Color(0f,0f,0f,d * 0.42f);
			}
			GetComponent<TextMesh>().color = new Color(1f,1f,1f,d);
		} 
	}
}
