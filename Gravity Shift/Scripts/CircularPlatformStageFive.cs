using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPlatformStageFive : MonoBehaviour {
	public GameObject platform;

	float timeCounter = 0;
	float speed;
	float width;
	float height;

	// Use this for initialization
	void Start () {
		speed = 0.7f;
		width = 20;
		height = 20;
	}

	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime * speed;
		float x = Mathf.Sin (timeCounter) * height;
		float y = 0;
		float z = Mathf.Cos (timeCounter) * width;

		platform.transform.position = new Vector3 (x+12, y+5, z+64);

	}
}
