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
	}

	public void Run () {
		Invoke("Reveal", 6f);
		Invoke("Smile", 10f);
		Invoke("ArmAroundShoulder", 16f);
		Invoke("BackgroundAnimation", 32f);
		Invoke("LickLips", 36f);
	}


	void Reveal () {
		shots[1].GetComponent<Part2Still>().Enable();
	}

	void Smile () {
		shots[2].GetComponent<Part2Still>().Enable();
		shots[3].GetComponent<Part2Animation>().Enable();
	}

	void ArmAroundShoulder () {
		shots[4].GetComponent<Part2Still>().Enable();
	}

	void BackgroundAnimation () {
		shots[5].GetComponent<SpriteRenderer>().enabled = true;
		shots[5].GetComponent<Part2Animation>().Enable();
	}

	void LickLips () {
		shots[6].GetComponent<Part2Animation>().Enable();
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
