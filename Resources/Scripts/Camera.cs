using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	Rigidbody2D rb;
	float speed = 0.5f;
	GameObject alana;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		alana = GameObject.Find("Alana");


		float start = 4f;

		Invoke("MoveToStairs", start);
		Invoke("MoveUpStairs", start + 13f);
		Invoke("MoveToPimp", 	 start + 18f);
		Invoke("TalkToPimp", 	 start + 22f);

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
	}

	void TalkToPimp () {
		Vector2 v = new Vector2(0f, 0f);
		rb.velocity = v;
		alana.GetComponent<Rigidbody2D>().velocity = v;
		alana.GetComponent<Animator>().SetBool("walk", false);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
