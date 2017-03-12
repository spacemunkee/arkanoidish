using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	public float speed = 6f;
	public float paddleAdjustment = 0.35f;
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position += new Vector3(Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0, 0);

		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		if (position.x + paddleAdjustment > widthOrtho) {
			position.x = widthOrtho - paddleAdjustment;
		}

		if (position.x - paddleAdjustment < -widthOrtho) {
			position.x = -widthOrtho + paddleAdjustment;
		}

		transform.position = position;
	}
}
