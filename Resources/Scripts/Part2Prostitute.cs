using UnityEngine;
using System.Collections;

public class Part2Prostitute : MonoBehaviour {

	GameObject[] shots;
	AudioSource[] audios; //breathing, clothes, drugBag, noise, sniff, zip, jacketoff, lick1, lick2

	// Use this for initialization
	void Start () {
		shots = new GameObject[10];
		for (int i = 0; i < 10; i++){
			shots[i] = GameObject.Find("Part2Prostitute/" + i);
		}
		audios = GetComponents<AudioSource>();
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
		Invoke("Sniff",  							start + 74f);
	}


	public void Mute () {
		for (int i = 0; i < audios.Length; i++) {
			audios[i].volume = 0f;
		}
	}

	public void Unmute () {
		for (int i = 0; i < audios.Length; i++) {
			audios[i].volume = 1f;
		}
	}


	void Reveal () {
		shots[1].GetComponent<Part2Still>().Enable();
		audios[6].Play();
	}

	void Smile () {
		shots[2].GetComponent<Part2Still>().Enable();
		shots[3].GetComponent<Part2Animation>().Enable();
		audios[7].Play();
	}

	void ArmAroundShoulder () {
		shots[4].GetComponent<Part2Still>().Enable();
	}

	void BackgroundAnimation () {
		shots[5].GetComponent<SpriteRenderer>().enabled = true;
		shots[5].GetComponent<Part2Animation>().Enable();
		audios[0].Play();
		audios[1].Play();
		audios[3].Play();
	}

	void LickLips () {
		shots[6].GetComponent<Part2Animation>().Enable();
		audios[8].Play();
	}

	void DressUp () {
		shots[5].SetActive(false);
		shots[7].GetComponent<Part2Still>().Enable();
		audios[5].Play();
	}

	void GiveReward () {
		shots[8].GetComponent<Part2Still>().Enable();
		audios[2].Play();
	}

	void TakeReward () {
		shots[9].GetComponent<Part2Still>().Enable();
	}

	void Sniff () {
		audios[4].Play();
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
