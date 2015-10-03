using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	Rigidbody2D rb;
	float speed = 0.1f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Invoke("MoveToStairs", 2f);
		Invoke("MoveUpStairs", 4f);
		Invoke("MoveToPimp", 	 6f);
		Invoke("TalkToPimp", 	 8f);

	}
	
	void MoveToStairs () {
		rb.velocity = new Vector2(speed, 0f);
	}

	void MoveUpStairs () {
		rb.velocity = new Vector2(speed, speed);
	}

	void MoveToPimp () {
		rb.velocity = new Vector2(speed, 0f);
	}

	void TalkToPimp () {
		rb.velocity = new Vector2(0f, 0f);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
