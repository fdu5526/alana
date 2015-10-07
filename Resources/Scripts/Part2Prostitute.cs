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
		float start = 0f;
		Invoke("Reveal", 					  	start + 12f);
		Invoke("Smile", 					  	start + 16f);
		Invoke("ArmAroundShoulder", 	start + 22f);
		Invoke("BackgroundAnimation", start + 38f);
		Invoke("LickLips",  					start + 42f);
		Invoke("DressUp",  					  start + 57f);
		Invoke("GiveReward",  				start + 68f);
		Invoke("TakeReward",  				start + 72f);
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

	void DressUp () {
		shots[5].SetActive(false);
		shots[7].GetComponent<Part2Still>().Enable();
	}

	void GiveReward () {
		shots[8].GetComponent<Part2Still>().Enable();
	}

	void TakeReward () {
		shots[9].GetComponent<Part2Still>().Enable();
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
