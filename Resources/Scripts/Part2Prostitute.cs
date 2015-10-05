using UnityEngine;
using System.Collections;

public class Part2Prostitute : MonoBehaviour {


	GameObject[] shots;

	// Use this for initialization
	void Start () {
		shots = new GameObject[10];
		for (int i = 0; i < 10; i++){
			shots[i] = GameObject.Find("Part2Prostitute/" + i);
		}

		Invoke("ShowShot5", 2f);
		Invoke("ShowShot6", 4f);


	}


	void ShowShot0 () {
		shots[0].GetComponent<Part2Still>().Enable();
	}

	void ShowShot1 () {
		shots[1].GetComponent<Part2Still>().Enable();
	}

	void ShowShot5 () {
		shots[5].GetComponent<SpriteRenderer>().enabled = true;
		shots[5].GetComponent<Part2Animation>().Enable();
	}

	void ShowShot6 () {
		shots[6].GetComponent<Part2Animation>().Enable();
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
