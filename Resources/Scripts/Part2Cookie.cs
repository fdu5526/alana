using UnityEngine;
using System.Collections;

public class Part2Cookie : MonoBehaviour {


	GameObject[] shots;

	// Use this for initialization
	void Start () {
		shots = new GameObject[10];
		for (int i = 0; i < 10; i++){
			shots[i] = GameObject.Find("Part2Cookie/" + i);
		}
	}

	public void Run () {
		float start = 0f;
		Invoke("Ruffle", 		 start + 4f);
		Invoke("ShowCookie", start + 11f);
		Invoke("OvenMits", 	 start + 22f);
		Invoke("PutInOven",  start + 38f);
		Invoke("Dial",  		 start + 47f);
		Invoke("OvenHeatUp", start + 50f);
		Invoke("CookieDone", start + 57f);
		Invoke("GiveReward", start + 68f);
		Invoke("TakeReward", start + 72f);
	}


	void Ruffle () {
		shots[1].GetComponent<Part2Still>().Enable();
	}

	void ShowCookie () {
		shots[2].GetComponent<Part2Still>().Enable();
	}

	void OvenMits () {
		shots[3].GetComponent<Part2Still>().Enable();
	}

	void PutInOven () {
		shots[4].GetComponent<Part2Still>().Enable();
	}

	void Dial () {
		shots[5].GetComponent<Part2Still>().Enable();
	}

	void OvenHeatUp () {
		shots[6].GetComponent<Part2Still>().Enable();
	}

	void CookieDone () {
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
