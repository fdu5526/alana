using UnityEngine;
using System.Collections;

public class Part2Cookie : MonoBehaviour {

	GameObject[] shots;
	AudioSource[] audios; // hair, metal, cookie, dial, ovenDoor, sparkle

	// Use this for initialization
	void Start () {
		shots = new GameObject[10];
		for (int i = 0; i < 10; i++){
			shots[i] = GameObject.Find("Part2Cookie/" + i);
		}
		audios = GetComponents<AudioSource>();
	}

	public void Run () {
		float start = 0f;
		Invoke("Ruffle", 		 start + 4f);
		Invoke("ShowCookie", start + 11f);
		Invoke("OvenMits", 	 start + 22f);
		Invoke("PutInOven",  start + 38f);
		Invoke("ShutOvenDoor", start + 47f);
		Invoke("Dial",  		 start + 47f);
		Invoke("OvenHeatUp", start + 50f);
		Invoke("CookieDone", start + 57f);
		Invoke("CookieSparkle", start + 59f);
		Invoke("GiveReward", start + 68f);
		Invoke("TakeReward", start + 72f);
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


	void Ruffle () {
		shots[1].GetComponent<Part2Still>().Enable();
		audios[0].Play();
	}

	void ShowCookie () {
		shots[2].GetComponent<Part2Still>().Enable();
	}

	void OvenMits () {
		shots[3].GetComponent<Part2Still>().Enable();
	}

	void PutInOven () {
		shots[4].GetComponent<Part2Still>().Enable();
		audios[1].Play();
	}

	void ShutOvenDoor () {
		audios[4].Play();
	}

	void Dial () {
		shots[5].GetComponent<Part2Still>().Enable();
	}

	void OvenHeatUp () {
		shots[6].GetComponent<Part2Still>().Enable();
		audios[3].Play();
	}

	void CookieDone () {
		shots[7].GetComponent<Part2Still>().Enable();
	}

	void CookieSparkle () {
		audios[5].Play();
	}

	void GiveReward () {
		shots[8].GetComponent<Part2Still>().Enable();
	}

	void TakeReward () {
		shots[9].GetComponent<Part2Still>().Enable();
		audios[2].Play();
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
