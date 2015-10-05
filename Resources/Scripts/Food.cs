using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Food : MonoBehaviour {

	float rate = 0.01f;
	
	public float transparency;

	float prevEnableTime;


	// Use this for initialization
	void Start () {
		transparency = 0f;
		prevEnableTime = 0f;
	}


	public void Enable () {
		transparency = 1f;
		prevEnableTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time - prevEnableTime > 1.5f) {
			transparency = Mathf.Max(0f, transparency - rate);
		}
		

		GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, transparency);
	}
}
