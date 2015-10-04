using UnityEngine;
using System.Collections;

public class Narrative : MonoBehaviour {

	Rigidbody2D rb;
	float speed = 0.5f;
	

	GameObject alana, char1, foreground1, foreground2, background;
	Sprite[] foreground1s, foreground2s, backgrounds;
	RuntimeAnimatorController[] alanaAnimator, char1Animator;
	BlackFade fade;

	int currentStory;
	int maxStory = 2;

	Dialogue[] dialogues;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		alana = GameObject.Find("Alana");
		char1 = GameObject.Find("Char1");
		foreground1 = GameObject.Find("foreground1");
		foreground2 = GameObject.Find("foreground2");
	 	background = GameObject.Find("background");
	 	fade = GameObject.Find("Canvas/Black").GetComponent<BlackFade>();

	 	// get all the stuff that switches
	 	string[] names = {"Prostitute", "Cookie"};
	 	foreground1s = new Sprite[names.Length];
	 	foreground2s = new Sprite[names.Length];
	 	backgrounds	 = new Sprite[names.Length];
	 	alanaAnimator = new RuntimeAnimatorController[names.Length];
	 	char1Animator = new RuntimeAnimatorController[names.Length];
	 	for (int i = 0; i < names.Length; i++) {
	 		foreground1s[i] = Resources.Load<Sprite>(names[i] + "/foreground1");
	 		foreground2s[i] = Resources.Load<Sprite>(names[i] + "/foreground2");
	 		backgrounds[i] = Resources.Load<Sprite>(names[i] + "/background");
	 		alanaAnimator[i] = Resources.Load<RuntimeAnimatorController>("Animations/" + names[i] + "Alana");
	 	}


	 	// dialogue initialization
		int numTexts = 11;
		dialogues = new Dialogue[numTexts];

		for (int i = 0; i < numTexts; i++) {
			dialogues[i] = GameObject.Find("Texts/Text " + i).GetComponent<Dialogue>();
		}


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

	}


	
	void MoveToStairs () {
		Vector2 v = new Vector2(speed, 0f);
		rb.velocity = v;
		alana.GetComponent<Rigidbody2D>().velocity = v;
		alana.GetComponent<Animator>().SetBool("walk", true);
	}

	void MoveUpStairs () {
		Vector2 v = new Vector2(0.67f, 0.224f);
		rb.velocity = new Vector2(0.1f, 0.1f);
		alana.GetComponent<Rigidbody2D>().velocity = v;
	}

	void MoveToPimp () {
		Vector2 v = new Vector2(speed, 0f);
		rb.velocity = v;
		alana.GetComponent<Rigidbody2D>().velocity = v;

		dialogues[0].Display(); // You're late.
	}

	void TalkToPimp1 () { 
		dialogues[1].Display(); // // sorry
	}

	void TalkToPimp2 () {
		Vector2 v = new Vector2(0f, 0f);
		rb.velocity = v;
		alana.GetComponent<Rigidbody2D>().velocity = v;
		alana.GetComponent<Animator>().SetBool("walk", false);
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
		alana.GetComponent<Rigidbody2D>().velocity = v;
		alana.GetComponent<Animator>().SetBool("walk", true);
		dialogues[10].Display(); // You got this.
	}

	void StopCamera () {
		rb.velocity = Vector2.zero;
	}

	void StopWalk () {
		alana.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		alana.GetComponent<Animator>().SetBool("walk", false);
	}


	void CutToKnock () {
		fade.rate = 0.1f;
		fade.state = BlackFade.FadeState.FadeIn;
	}


	void Switch () {
		currentStory = currentStory + 1 == maxStory ? 0 : currentStory + 1;

		background.GetComponent<SpriteRenderer>().sprite = backgrounds[currentStory];
		foreground1.GetComponent<SpriteRenderer>().sprite = foreground1s[currentStory];
		foreground2.GetComponent<SpriteRenderer>().sprite = foreground2s[currentStory];

		bool state = alana.GetComponent<Animator>().GetBool("walk");

		alana.GetComponent<Animator>().runtimeAnimatorController = alanaAnimator[currentStory];
		alana.GetComponent<Animator>().SetBool("walk", state);


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			Switch();
		}
	}
}
