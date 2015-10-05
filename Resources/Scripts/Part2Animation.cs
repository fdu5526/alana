using UnityEngine;
using System.Collections;

public class Part2Animation : MonoBehaviour {

	public int frameCount;
	public bool shouldLoop;
	public bool shouldRemain;
	public string path;
	public float transitionDuration;
	public float displayDuration;
	public Vector2 velocity;

	bool isEnabled = false;

	int currentFrame, prevFrame;
	float lastSwitchTime;

	GameObject[] frames;

	// Use this for initialization
	void Start () {

		currentFrame = 0;
		prevFrame = -1;
		lastSwitchTime = 0;

		int sortingOrder = GetComponent<SpriteRenderer>().sortingOrder;
		GetComponent<SpriteRenderer>().sortingOrder = sortingOrder - 1;


		frames = new GameObject[frameCount];
		for (int i = 0; i < frameCount; i++) {
			frames[i] = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/part2Animation"));
			frames[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path + i.ToString());
			frames[i].GetComponent<SpriteRenderer>().color = Color.clear;
			frames[i].GetComponent<SpriteRenderer>().sortingOrder = sortingOrder;
			frames[i].GetComponent<Transform>().position = GetComponent<Transform>().position;
			frames[i].GetComponent<Transform>().localScale = GetComponent<Transform>().localScale;
		}
	}

	public void Enable () {
		isEnabled = true;

		for (int i = 0; i < frameCount; i++) {
			frames[i].GetComponent<Rigidbody2D>().velocity = velocity;
		}

		lastSwitchTime = Time.time;
		
	}


	
	// Update is called once per frame
	void Update () {

		if (!isEnabled) {
			return;
		}
		
		if (currentFrame == frameCount) {
			if (!shouldRemain) {
				float t = Mathf.Min((Time.time - lastSwitchTime) / transitionDuration, 1f);
				if (prevFrame >= 0) {
					frames[prevFrame].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f - t);
				}
				if (t > 0.99f) {
					isEnabled = false;
				}
			}
			return;
		}


		if (Time.time - lastSwitchTime <= transitionDuration) {
			float t = Mathf.Min((Time.time - lastSwitchTime) / transitionDuration, 1f);
			float c = (currentFrame == 0) ? 0f : 0.7f;
			frames[currentFrame].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, c + t);
			if (prevFrame >= 0) {
				frames[prevFrame].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f - t);
			}
		} else {
			frames[currentFrame].GetComponent<SpriteRenderer>().color = Color.white;
		}
		if (Time.time - lastSwitchTime > displayDuration) {
			lastSwitchTime = Time.time;

			if (prevFrame >= 0) {
				frames[prevFrame].GetComponent<SpriteRenderer>().color = Color.clear;
			}	
			prevFrame = currentFrame;
			currentFrame = ((currentFrame + 1 == frameCount) && shouldLoop) ? 0 : currentFrame + 1;
		}



	}
}
