using UnityEngine;
using System.Collections;

public class Flicker : MonoBehaviour {

	float prevFlickerTime;
	float flickerCooldown;
	Color flickOff;

	// Use this for initialization
	void Start () {
		flickerCooldown = NewFlickerTime;
		prevFlickerTime = -flickerCooldown;
		flickOff = new Color(1f,1f,1f, 0.8f);
	}


	float NewFlickerTime { get { return UnityEngine.Random.Range(0.1f, 0.5f); }}

	void FlickOff () {
		GetComponent<SpriteRenderer>().color = flickOff;
	}

	void FlickOn () {
		GetComponent<SpriteRenderer>().color = Color.white;
	}

	
	// Update is called once per frame
	void Update () {
		if (Time.time - prevFlickerTime > flickerCooldown) {
			prevFlickerTime = Time.time;
			flickerCooldown = NewFlickerTime;

			FlickOff();
			Invoke("FlickOn", 0.05f);

		}
	}
}
