using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlackFade : MonoBehaviour {


	public enum FadeState { None, FadeIn, FadeOut };

	public FadeState state;
	public float rate = 0.01f;
	
	float t;


	// Use this for initialization
	void Start () {
		state = FadeState.None;
		t = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
			case FadeState.FadeIn:
				t = Mathf.Min(1f, t + rate);
				break;
			case FadeState.FadeOut:
				t = Mathf.Max(0f, t - rate);
				break;
		}

		GetComponent<Image>().color = new Color(0f, 0f, 0f, t);
	}
}
