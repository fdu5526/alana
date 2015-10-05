using UnityEngine;
using System.Collections;

public class Part2Still : MonoBehaviour {

	public float transitionDuration;
	public Vector2 velocity;

	float lastSwitchTime;
	bool enabled;

	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = Color.clear;
		enabled = false;
	}

	public void Enable () {
		enabled = true;
		lastSwitchTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (!enabled) {
			return;
		}
		if (Time.time - lastSwitchTime <= transitionDuration) {	// fade in
			float t = Mathf.Min((Time.time - lastSwitchTime) / transitionDuration, 1f);
			spriteRenderer.color = new Color(1f, 1f, 1f, t);
		}
	}
}
