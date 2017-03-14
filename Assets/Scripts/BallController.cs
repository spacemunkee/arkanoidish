using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float speedX;
	public float speedY;

	void Start() {
		if(speedX == 0) {
			speedX = 1; 
		}
		if(speedY == 0) {
			speedY = 1;
		}
	}

	// Update is called once per frame
	void Update () {
		var dist = (transform.position - Camera.main.transform.position).z;
		var left = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).x;
		var right = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, dist)).x;
		var bottom = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).y;
		var top = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, dist)).y;

		if (transform.position.x <= left) {
			speedX = -speedX;
		}

		if (transform.position.x >= right) { 
			speedX = -speedX;
		}

		if (transform.position.y <= bottom) {
			speedY = -speedY;
		}

		if (transform.position.y >= top) {
			speedY = -speedY;
		}

		transform.position += new Vector3 (speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Paddle")) {
			speedY = -speedY;
		}
	}
}
