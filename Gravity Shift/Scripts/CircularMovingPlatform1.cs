using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovingPlatform1 : MonoBehaviour {
	public GameObject platform;

	float timeCounter = 0;
	float speed;
	float width;
	float height;

	// Use this for initialization
	void Start () {
		speed = 1f;
		width = 9;
		height = 7;
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime * speed;
		float x = Mathf.Sin (timeCounter) * height;
		float y = Mathf.Cos (timeCounter) * width;
		float z = 21;

		platform.transform.position = new Vector3 (x, y, z);

	}
}
