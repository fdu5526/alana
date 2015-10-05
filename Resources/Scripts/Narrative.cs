using UnityEngine;
using System.Collections;

public class Narrative : MonoBehaviour {

	Rigidbody2D rb;
	float speed = 0.5f;
	

	GameObject foreground1, foreground2, background;

	GameObject[] alana, char1;
	Sprite[] foreground1s, foreground2s, backgrounds;
	BlackFade fade;

	string[] names = {"Prostitute", "Cookie"};

	int currentStory = 0;
	int maxStory;

	int currentPart = 1;

	Vector3[] part2CameraPositions;
	

	Dialogue[] dialogues;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();		
		maxStory = names.Length;
		fade = GameObject.Find("Canvas/Black").GetComponent<BlackFade>();

		// TODO
		currentPart = 1;
		PlayPart1();


	}


	void PlayPart2 () {
		// initialize all camera positions
		part2CameraPositions = new Vector3[maxStory];
		for (int i = 0; i < maxStory; i++){
			part2CameraPositions[i] = new Vector3(-8.66f - 20.31f * (float)(i+1), -0.3f, -10f);
		}

		
		int numTexts = 15;
		dialogues = new Dialogue[numTexts];

		for (int i = 0; i < numTexts; i++) {
			dialogues[i] = GameObject.Find("MainCamera/Text " + i).GetComponent<Dialogue>();
		}


		// move to correct camera location
		GetComponent<Transform>().position = part2CameraPositions[currentStory];

		// fade to black
		fade.rate = 0.01f;
		fade.state = BlackFade.FadeState.FadeOut;

		
		float start = 0f;
		Invoke("RunPart2Animations",start);
		Invoke("TalkToClient0", 		start);
		Invoke("TalkToClient1", 		start + 3f);
		Invoke("TalkToClient2", 		start + 7f);
		Invoke("TalkToClient3", 		start + 18f);
		Invoke("TalkToClient4", 		start + 24f);
		Invoke("TalkToClient5", 		start + 30f);
		Invoke("FadeToBlack", 			start + 34f);
		Invoke("FadeFromBlack", 		start + 38f);


		Invoke("TalkToClient6", 		start + 43f);
		Invoke("TalkToClient7", 		start + 45f);
		Invoke("TalkToClient8", 		start + 49f);
		
		Invoke("FadeToBlack", 			start + 53f);
		Invoke("FadeFromBlack", 		start + 57f);

		Invoke("TalkToClient9", 		start + 59f);
		Invoke("TalkToClient10",  	start + 64f);

		Invoke("TalkToClient11",  	start + 69f);
		Invoke("TalkToClient12",  	start + 74f);
		Invoke("TalkToClient13",  	start + 79f);
		Invoke("TalkToClient14",  	start + 81f);
	}


	void RunPart2Animations () {
		GameObject.Find("Part2Prostitute").GetComponent<Part2Prostitute>().Run();
	}

	void TalkToClient0 () { // Come in.
		dialogues[0].Display();
	}

	void TalkToClient1 () { // Alana! It's been a while. I haven't seen you in so long.
		dialogues[1].Display();
	}

	void TalkToClient2 () { // What have you got this time? Show me.
		dialogues[2].Display();
	}

	void TalkToClient3 () { // Fantastic!
		dialogues[3].Display();
	}

	void TalkToClient4 () { //  I know this is hard for you
		dialogues[4].Display();
	}

	void TalkToClient5 () { // I'll do my best.
		dialogues[5].Display();
	}

	void FadeToBlack () {
		fade.rate = 0.01f;
		fade.state = BlackFade.FadeState.FadeIn;
	}

	void FadeFromBlack () {
		fade.rate = 0.01f;
		fade.state = BlackFade.FadeState.FadeOut;
	}


	void TalkToClient6 () { // Take it slow.
		dialogues[6].Display();
	}

	void TalkToClient7 () { // Y-Yeah.
		dialogues[7].Display();
	}

	void TalkToClient8 () { // Here, this, it won't hurt.
		dialogues[8].Display();
	}

	void TalkToClient9 () { // Great job, Alana!
		dialogues[9].Display();
	}

	void TalkToClient10 () { // Much better this time.
		dialogues[10].Display();
	}

	void TalkToClient11 () { // Here.
		dialogues[11].Display();
	}

	void TalkToClient12 () { // Do you like it?
		dialogues[12].Display();
	}

	void TalkToClient13 () { // It's... great...
		dialogues[13].Display();
	}

	void TalkToClient14 () { // That's good.
		dialogues[14].Display();
	}












	void PlayPart1 () {

		GetComponent<Transform>().position = new Vector3(-8.66f, -0.3f, -10f);

		foreground1 = GameObject.Find("foreground1");
		foreground2 = GameObject.Find("foreground2");
	 	background = GameObject.Find("background");

	 	// get all the stuff that switches
	 	alana = new GameObject[maxStory];
		char1 = new GameObject[maxStory];
	 	foreground1s = new Sprite[maxStory];
	 	foreground2s = new Sprite[maxStory];
	 	backgrounds	 = new Sprite[maxStory];
	 	for (int i = 0; i < maxStory; i++) {
	 		alana[i] = GameObject.Find("Alana/" + names[i]);
	 		char1[i] = GameObject.Find("Char1/" + names[i]);
	 		foreground1s[i] = Resources.Load<Sprite>(names[i] + "/foreground1");
	 		foreground2s[i] = Resources.Load<Sprite>(names[i] + "/foreground2");
	 		backgrounds[i] = Resources.Load<Sprite>(names[i] + "/background");
	 	}

	 	for (int i = 0; i < maxStory; i++) {
			if (i == currentStory) {
				alana[i].GetComponent<SpriteRenderer>().sortingOrder = 2;
				char1[i].GetComponent<SpriteRenderer>().sortingOrder = 1;
			} else {
				alana[i].GetComponent<SpriteRenderer>().sortingOrder = -100;
				char1[i].GetComponent<SpriteRenderer>().sortingOrder = -100;
			}
		}


	 	// dialogue initialization
		int numTexts = 11;
		dialogues = new Dialogue[numTexts];

		for (int i = 0; i < numTexts; i++) {
			dialogues[i] = GameObject.Find("Texts/Text " + i).GetComponent<Dialogue>();
		}

		//TODO change to 4
		float start = 0f;

		Invoke("MoveToStairs", start);
		Invoke("MoveUpStairs", start + 13f);
		
		Invoke("MoveToPimp", 	 start + 18.5f);
		Invoke("TalkToPimp1",  start + 20f);
		Invoke("TalkToPimp2",  start + 24f);
		Invoke("TalkToPimp3",  start + 28f);
		Invoke("TalkToPimp4",  start + 30f);
		Invoke("TalkToPimp5",  start + 34f);
		Invoke("TalkToPimp6",  start + 37f);
		Invoke("TalkToPimp7",  start + 38f);
		Invoke("TalkToPimp8",  start + 40f);
		Invoke("TalkToPimp9",  start + 42f);
		Invoke("TalkToPimp10", start + 44f);

		Invoke("StopCamera", 	 start + 54f);
		Invoke("StopWalk", 		 start + 63f);
		Invoke("CutToKnock", 	 start + 67f);
		Invoke("Knock", 	 start + 70f);
		Invoke("MoveToPart2", 	 start + 72f);
	}


	
	void MoveToStairs () {
		Vector2 v = new Vector2(speed, 0f);
		rb.velocity = v;
		for (int i = 0; i < maxStory; i++) {
			alana[i].GetComponent<Rigidbody2D>().velocity = v;
			alana[i].GetComponent<Animator>().SetBool("walk", true);
		}
	}

	void MoveUpStairs () {
		Vector2 v = new Vector2(0.67f, 0.224f);
		rb.velocity = new Vector2(0.1f, 0.1f);
		for (int i = 0; i < maxStory; i++) {
			alana[i].GetComponent<Rigidbody2D>().velocity = v;
		}
	}

	void MoveToPimp () {
		Vector2 v = new Vector2(speed, 0f);
		rb.velocity = v;
		for (int i = 0; i < maxStory; i++) {
			alana[i].GetComponent<Rigidbody2D>().velocity = v;
		}
		dialogues[0].Display(); // You're late.
	}

	void TalkToPimp1 () { 
		dialogues[1].Display(); // // sorry
	}

	void TalkToPimp2 () {
		Vector2 v = new Vector2(0f, 0f);
		rb.velocity = v;
		for (int i = 0; i < maxStory; i++) {
			alana[i].GetComponent<Rigidbody2D>().velocity = v;
			alana[i].GetComponent<Animator>().SetBool("walk", false);
		}
		dialogues[2].Display(); // is there any food left?
	}

	void TalkToPimp3 () {
		dialogues[3].Display(); // here
	}

	void TalkToPimp4 () {
		dialogues[4].Display(); // thanks
	}

	void TalkToPimp5 () {
		dialogues[5].Display(); // So, are you ready?
	}

	void TalkToPimp6 () {
		dialogues[6].Display(); // Don't mess up this time.
	}

	void TalkToPimp7 () {
		dialogues[7].Display(); // I'll do my best.
	}

	void TalkToPimp8 () {
		dialogues[8].Display(); // Alright.
	}

	void TalkToPimp9 () {
		dialogues[9].Display(); // Go.
	}

	void TalkToPimp10 () {
		Vector2 v = new Vector2(speed, 0f);
		rb.velocity = v;
		for (int i = 0; i < maxStory; i++) {
			alana[i].GetComponent<Rigidbody2D>().velocity = v;
			alana[i].GetComponent<Animator>().SetBool("walk", true);
		}
		dialogues[10].Display(); // You got this.
	}

	void StopCamera () {
		rb.velocity = Vector2.zero;
	}

	void StopWalk () {
		for (int i = 0; i < maxStory; i++) {
			alana[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			alana[i].GetComponent<Animator>().SetBool("walk", false);
		}
	}


	void CutToKnock () {
		fade.rate = 0.01f;
		fade.state = BlackFade.FadeState.FadeIn;
	}

	void Knock () {
		// TODO play knock sound
	}

	void MoveToPart2 () {
		currentPart = 2;
		PlayPart2();
	}

	// replace all sprites to switch scenes
	void SwitchPart1 () {
		currentStory = currentStory + 1 == maxStory ? 0 : currentStory + 1;

		background.GetComponent<SpriteRenderer>().sprite = backgrounds[currentStory];
		foreground1.GetComponent<SpriteRenderer>().sprite = foreground1s[currentStory];
		foreground2.GetComponent<SpriteRenderer>().sprite = foreground2s[currentStory];

		
		for (int i = 0; i < maxStory; i++) {
			if (i == currentStory) {
				alana[i].GetComponent<SpriteRenderer>().sortingOrder = 2;
				char1[i].GetComponent<SpriteRenderer>().sortingOrder = 1;
			} else {
				alana[i].GetComponent<SpriteRenderer>().sortingOrder = -100;
				char1[i].GetComponent<SpriteRenderer>().sortingOrder = -100;
			}
		}
	}

	// just move camera
	void SwitchPart2 () {
		currentStory = currentStory + 1 == maxStory ? 0 : currentStory + 1;
		GetComponent<Transform>().position = part2CameraPositions[currentStory];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			if (currentPart == 1) {
				SwitchPart1();
			} else {
				SwitchPart2();
			}
		}
	}
}
