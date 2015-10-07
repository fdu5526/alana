using UnityEngine;
using System.Collections;

public class MouseUI : MonoBehaviour {

	float t;
	bool isEnabled;
	float startTime;

	float rate = 0.01f;
	float transitionDuration = 1f;
	float duration = 5f;

	// Use this for initialization
	void Start () {
		t = 0f;
		isEnabled = false;
		GetComponent<SpriteRenderer>().color = Color.clear;
	}


	public void Enable () {
		startTime = Time.time;
		isEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isEnabled) {
			return;
		}

		float d = Time.time - startTime;
		if (d < transitionDuration) { // fade in
			t = Mathf.Min(1f, t + rate);
		} else if (d > transitionDuration + duration &&
							 d < transitionDuration + 2f * duration) { // fade out
			t = Mathf.Max(0f, t - rate);
		} else if (d > transitionDuration + 2f * duration) {
			isEnabled = false;
		}

		GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, t);
	}
}
